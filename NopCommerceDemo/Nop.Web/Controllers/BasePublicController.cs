﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Nop.Web.Controllers
{
    public class BasePublicController : Controller
    {
        //
        // GET: /BasePublic/
        public ActionResult Index()
        {
            return View();
        }
	}
}