using Nop.Core.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Nop.Web.Controllers
{
    public class InstallController : Controller
    {
        #region Methods

        public ActionResult Index()
        {
            if (DataSettingsHelper.DatabaseIsInstalled())
                return RedirectToRoute("HomePage");

            // set page timeout to 5 minutes
            this.Server.ScriptTimeout = 300;

            //var model=new 


            return Content("Install");
        }

        #endregion Methods
    }
}