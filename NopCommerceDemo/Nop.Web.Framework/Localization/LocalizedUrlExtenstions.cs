using Nop.Core.Domain.Localization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nop.Web.Framework.Localization
{
    public static class LocalizedUrlExtenstions
    {
        private static int _seoCodeLength = 2;

        /// <summary>
        /// Returns a value indicating whether nopCommerce is run in virtual
        /// directory
        /// </summary>
        /// <param name="applicationPath">Application path</param>
        /// <returns>Result</returns>
        private static bool IsVirtualDirectory(this string applicationPath)
        {
            if (string.IsNullOrEmpty(applicationPath))
                throw new ArgumentException("Application path is not specified");

            return applicationPath != "/";
        }

        /// <summary>
        /// Remove application path from raw URL
        /// </summary>
        /// <param name="rawUrl">Raw URL</param>
        /// <param name="applicationPath">Application path</param>
        /// <returns>Result</returns>
        public static string RemoveApplicationPathFromRawUrl(this string rawUrl,string applicationPath)
        {
            if (string.IsNullOrEmpty(applicationPath))
                throw new ArgumentException("Application path is not specified");

            if (rawUrl.Length == applicationPath.Length)
                return "/";

            var result = rawUrl.Substring(applicationPath.Length);
            // raw url always starts with '/'
            if (!result.StartsWith("/"))
                result = "/" + result;

            return result;
        }




        /// <summary>
        /// Get a value indicating whether URL is localized (contains SEO code)
        /// </summary>
        /// <param name="url">URL</param>
        /// <param name="applicationPath">Application path</param>
        /// <param name="isRawPath">a value indicating whether raw URL is passed</param>
        /// <returns>Result</returns>
        public static bool IsLocalizedUrl(this string url, string applicationPath, bool isRawPath)
        {
            if (string.IsNullOrEmpty(url))
                return false;

            if (isRawPath)
            {
                if(applicationPath.IsVirtualDirectory())
                {
                    // we're in virtual directory. So remove its path
                    url = url.RemoveApplicationPathFromRawUrl(applicationPath);
                }

                int length = url.Length;
                // too short url
                if (length < 1 + _seoCodeLength)
                    return false;

                // url like "/en"
                if (length == 1 + _seoCodeLength)
                    return true;

                // urls like "/en/" or "/en/somethingelse"
                return (length > 1 + _seoCodeLength) && (url[1 + _seoCodeLength] == '/');
            }
            else
            {
                int length = url.Length;
                // too short url
                if (length < 2 + _seoCodeLength)
                    return false;

                // url like "/en"
                if (length == 2 + _seoCodeLength)
                    return true;

                // urls like "/en/" or "/en/somethingelse"
                return (length > 2 + _seoCodeLength) && (url[2 + _seoCodeLength] == '/');
            }
        }

        //-->>

        /// <summary>
        /// Add language SEO code from URL
        /// </summary>
        /// <param name="url">Raw URL</param>
        /// <param name="applicationPath">Application path</param>
        /// <param name="language">Language</param>
        /// <returns>Result</returns>
        public static string AddLanguageSeoCodeToRawUrl(this string url,string applicationPath,Language language)
        {
            if (language == null)
                throw new ArgumentNullException("language");

            // null validation is not required
            //if (string.IsNullOrEmpty(url))
            //    return url;

            int startIndex = 0;
            if(applicationPath.IsVirtualDirectory())
            {
                // we're in virtual directory.
                startIndex = applicationPath.Length;
            }

            // add SEO code
            url = url.Insert(startIndex, language.UniqueSeoCode);
            url = url.Insert(startIndex, "/");

            return url;
        }



    }
}
