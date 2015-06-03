using Nop.Core.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nop.Web.Framework.ViewEngines.Razor
{
    public abstract class WebViewPage<TModel> : System.Web.Mvc.WebViewPage<TModel>
    {
        //private ILocalizationService








        public override void InitHelpers()
        {
            base.InitHelpers();

            if(DataSettingsHelper.DatabaseIsInstalled())
            {

            }
        }





    }

    public abstract class WebViewPage : WebViewPage<dynamic>
    {

    }

}
