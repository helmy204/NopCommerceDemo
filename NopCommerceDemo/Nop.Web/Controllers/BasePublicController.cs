using Nop.Web.Framework;
using Nop.Web.Framework.Controllers;
using Nop.Web.Framework.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Nop.Web.Controllers
{
    [CheckAffiliate]
    [StoreClosed]
    [PublicStoreAllowNavigation]
    [LanguageSeoCode]
    [NopHttpsRequirement(SslRequirement.NoMatter)]
    //-->>
    public class BasePublicController : BaseController
    {

    }
}