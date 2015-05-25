using FluentValidation.Attributes;
using Nop.Web.Validators.Install;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Nop.Web.Models.Install
{
    [Validator(typeof(InstallValidator))]
    public partial class InstallModel
    {
    }
}