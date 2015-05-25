﻿using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.SessionState;

namespace Nop.Core.Fakes
{
    // TODO: Not Finished
    public class FakeHttpContext : HttpContextBase
    {
        private readonly HttpCookieCollection _cookies;
        private readonly NameValueCollection _formParams;
        private IPrincipal _principal;
        private readonly NameValueCollection _queryStringParams;
        private readonly string _relativeUrl;
        private readonly string _method;
        private readonly SessionStateItemCollection _sessionItems;
        private readonly NameValueCollection _serverVariables;
        //-->>
        //-->>
        private readonly Dictionary<object, object> _items;


        public FakeHttpContext(string relativeUrl)
            : this(relativeUrl, null, null, null, null, null, null)
        {
        }

        public FakeHttpContext(string relativeUrl,
            IPrincipal principal,NameValueCollection formParams,
            NameValueCollection queryStringParams,HttpCookieCollection cookies,
            SessionStateItemCollection sessionItems,NameValueCollection serverVariables)
            : this(relativeUrl, null, principal, formParams, queryStringParams, cookies, sessionItems, serverVariables)
        {
        }

        public FakeHttpContext(string relativeUrl,string method,
            IPrincipal principal,NameValueCollection formParams,
            NameValueCollection queryStringParams,HttpCookieCollection cookies,
            SessionStateItemCollection sessionItems,NameValueCollection serverVariables)
        {
            _relativeUrl = relativeUrl;
            _method = method;
            _principal = principal;
            _formParams = formParams;
            _queryStringParams = queryStringParams;
            _cookies = cookies;
            _sessionItems = sessionItems;
            _serverVariables = serverVariables;

            _items = new Dictionary<object, object>();
        }
    }
}
