﻿using Nop.Web.Framework.Validators;
using Nop.Web.Infrastructure.Installation;
using Nop.Web.Models.Install;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Nop.Web.Validators.Install
{
    public class InstallValidator : BaseNopValidator<InstallModel>
    {
        public InstallValidator(IInstallationLocalizationService locService)
        {
            //RuleFor(x=>x.A)
        }
    }
}