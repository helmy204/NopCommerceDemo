using Nop.Core.Data;
using Nop.Core.Infrastructure;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Nop.Core
{
    /// <summary>
    /// Represents a common helper
    /// </summary>
    public partial class WebHelper : IWebHelper
    {
        #region Fields

        private readonly HttpContextBase _httpContext;

        #endregion Fields

        #region Utilities

        protected virtual Boolean IsRequestAvailable(HttpContextBase httpContext)
        {
            if (httpContext == null)
                return false;

            try
            {
                if (httpContext.Request == null)
                    return false;
            }
            catch (HttpException)
            {
                return false;
            }

            return true;
        }

        #endregion Utilities

        #region Methods

        /// <summary>
        /// Ctor
        /// </summary>
        /// <param name="httpContext">HTTP context</param>
        public WebHelper(HttpContextBase httpContext)
        {
            this._httpContext = httpContext;
        }

        /// <summary>
        /// Get URL referrer
        /// </summary>
        /// <returns>URL referrer</returns>
        public string GetUrlReferrer()
        {
            string referrerUrl = string.Empty;

            // URL referrer is null in some case (for example, in IE 8)
            if (IsRequestAvailable(_httpContext) && _httpContext.Request.UrlReferrer != null)
                referrerUrl = _httpContext.Request.UrlReferrer.PathAndQuery;

            return referrerUrl;
        }

        /// <summary>
        /// Get context IP address
        /// </summary>
        /// <returns>URL referrer</returns>
        public string GetCurrentIpAddress()
        {
            if (!IsRequestAvailable(_httpContext))
                return string.Empty;

            var result = "";
            if (_httpContext.Request.Headers != null)
            {
                // The X-Forwaded-For (XFF) HTTP header field is a de facto
                // standard for identifying the originating IP address of 
                // a client connecting to a web server through an HTTP
                // proxy or load balancer.
                var forwardedHttpHeader = "X-FORWARDED-FOR";
                if (!String.IsNullOrEmpty(ConfigurationManager.AppSettings["ForwardedHTTPheader"]))
                {
                    // but in some cases server use other HTTP header
                    // in these cases an administrator can specify
                    // a custom Forwarded HTTP header
                    forwardedHttpHeader = ConfigurationManager.AppSettings["ForwardedHTTPheader"];
                }

                // it's used for identifying the originating IP address of
                // a client connecting to a web server through an HTTP
                // proxy or load balancer.
                string xff = _httpContext.Request.Headers.AllKeys
                    .Where(x => forwardedHttpHeader.Equals(x, StringComparison.InvariantCultureIgnoreCase))
                    .Select(k => _httpContext.Request.Headers[k])
                    .FirstOrDefault();

                // if you want to exclude private IP addresses, then see  http://stackoverflow.com/questions/2577496/how-can-i-get-the-clients-ip-address-in-asp-net-mvc
                if (!String.IsNullOrEmpty(xff))
                {
                    string lastIp = xff.Split(new[] { ',' }).FirstOrDefault();
                    result = lastIp;
                }
            }

            if (String.IsNullOrEmpty(result) && _httpContext.Request.UserHostAddress != null)
            {
                result = _httpContext.Request.UserHostAddress;
            }

            // some validation
            if (result == "::1")
                result = "127.0.0.1";

            // remove port
            if (!String.IsNullOrEmpty(result))
            {
                int index = result.IndexOf(":", StringComparison.InvariantCultureIgnoreCase);
                if (index > 0)
                    result = result.Substring(0, index);
            }

            return result;
        }

        /// <summary>
        /// Gets this page name
        /// </summary>
        /// <param name="includeQueryString">Value indicating whether to include query strings</param>
        /// <returns>Page name</returns>
        public string GetThisPageUrl(bool includeQueryString)
        {
            bool useSsl = IsCurrentConnectionSecured();
            return GetThisPageUrl(includeQueryString, useSsl);
        }

        /// <summary>
        /// Gets this page name
        /// </summary>
        /// <param name="includeQueryString">Value indicating whether to include query strings</param>
        /// <param name="useSsl">Value indicating whether to get SSL protected page</param>
        /// <returns>Page name</returns>
        public string GetThisPageUrl(bool includeQueryString, bool useSsl)
        {
            string url = string.Empty;
            if (!IsRequestAvailable(_httpContext))
                return url;

            if (includeQueryString)
            {
                //string storeHost
            }



            return url;
        }

        /// <summary>
        /// Gets a value indicating whether current connection is secured
        /// </summary>
        /// <returns>true - secured , false - not secured</returns>
        public bool IsCurrentConnectionSecured()
        {
            bool useSsl = false;
            if (IsRequestAvailable(_httpContext))
            {
                useSsl = _httpContext.Request.IsSecureConnection;
                // when your hosting uses a load balancer on their
                // server the Request.IsSecureConnection is never
                // got set to true, use the statement below
                // just uncomment it
                //useSsl = _httpContext.Request.ServerVariables["HTTP-CLUSTER-HTTPS"] == "on" ? true : false;
            }

            return useSsl;
        }

        /// <summary>
        /// Gets server variable by name
        /// </summary>
        /// <param name="name">Name</param>
        /// <returns>Server variable</returns>
        public string ServerVariables(string name)
        {
            string result = string.Empty;

            try
            {
                if (!IsRequestAvailable(_httpContext))
                    return result;

                // put this method in try-catch
                // as described here  http://www.nopcommerce.com/boards/t/21356/multi-store-roadmap-lets-discuss-update-done.aspx?p=6#90196
                if (_httpContext.Request.ServerVariables[name] != null)
                {
                    result = _httpContext.Request.ServerVariables[name];
                }
            }
            catch
            {
                result = string.Empty;
            }
            return result;
        }

        /// <summary>
        /// Gets store host location
        /// </summary>
        /// <param name="useSsl">Use SSL</param>
        /// <returns>Store host location</returns>
        public string GetStoreHost(bool useSsl)
        {
            var result = "";
            var httpHost = ServerVariables("HTTP-HOST");
            if (!String.IsNullOrEmpty(httpHost))
            {
                result = "http://" + httpHost;
                if (!result.EndsWith("/"))
                    result += "/";
            }

            if(DataSettingsHelper.DatabaseIsInstalled())
            {
                #region Databse is installed

                // let's resolve IWorkContext here.
                // Do not inject it via constructor because it'll
                // cause circular refrences
                var storeContext = EngineContext.Current.Resolve<IStoreContext>();
                var currentStore = storeContext.CurrentStore;
                if (currentStore == null)
                    throw new Exception("Current store cannot be loaded");

                if (String.IsNullOrWhiteSpace(httpHost))
                {
                    // HTTP_HOST variable is not available.
                    // This scenario is possible only when HttpContext is not available
                    // (for example, running in a schedule task)
                    // in this case use URL of a store entity configured in admin area
                    result = currentStore.Url;
                    if (!result.EndsWith("/"))
                        result += "/";
                }

                if (useSsl)
                {
                    if (!String.IsNullOrWhiteSpace(currentStore.SecureUrl))
                    {
                        // Secure URL specified.
                        // So a store owner don't want it to be detected automatically.
                        // In this case let's use the specified secure URL
                        result = currentStore.SecureUrl;
                    }
                    else
                    {
                        // Secure URL is not specified.
                        // So a store owner wants it to be detected automatically.
                        result = result.Replace("http:/", "https:/");
                    }
                }
                else
                {
                    if (currentStore.SslEnabled && !String.IsNullOrWhiteSpace(currentStore.SecureUrl))
                    {
                        // SSL is enabled in this store and secure URL is specified.
                        // So a store owner don't want it to be detected automatically.
                        // In this case let's use the specified non-secure URL
                        result = currentStore.Url;
                    }
                }

                #endregion Databse is installed
            }
            else
            {
                #region Database is not installed
                if (useSsl)
                {
                    // Secure URL is not specified.
                    // So a store owner wants it to be detected automatically.
                    result = result.Replace("http:/", "https:/");
                }
                #endregion Database is not installed
            }

            if (!result.EndsWith("/"))
                result += "/";
            return result.ToLowerInvariant();
        }

        #endregion Methods


        public string GetStoreLocation()
        {
            throw new NotImplementedException();
        }

        public string GetStoreLocation(bool useSsl)
        {
            throw new NotImplementedException();
        }

        public bool IsStaticResource(System.Web.HttpRequest request)
        {
            throw new NotImplementedException();
        }

        public string MapPath(string path)
        {
            throw new NotImplementedException();
        }

        public string ModifyQueryString(string url, string queryStringModification, string anchor)
        {
            throw new NotImplementedException();
        }

        public string RemoveQueryString(string url, string queryString)
        {
            throw new NotImplementedException();
        }

        public T QueryString<T>(string name)
        {
            throw new NotImplementedException();
        }

        public void RestartAppDomain(bool makeRedirect = false, string redirectUrl = "")
        {
            throw new NotImplementedException();
        }

        public bool IsRequestBeingRedirected
        {
            get { throw new NotImplementedException(); }
        }

        public bool IsPostBeginDone
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }
    }
}
