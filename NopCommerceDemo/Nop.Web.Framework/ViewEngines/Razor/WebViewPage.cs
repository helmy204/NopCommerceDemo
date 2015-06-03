using Nop.Core;
using Nop.Core.Data;
using Nop.Core.Infrastructure;
using Nop.Services.Localization;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Nop.Web.Framework.ViewEngines.Razor
{
    public abstract class WebViewPage<TModel> : System.Web.Mvc.WebViewPage<TModel>
    {
        private ILocalizationService _localizationService;
        //-->>
        private IWorkContext _workContext;

        //-->>

        //-->>

        public override void InitHelpers()
        {
            base.InitHelpers();

            if(DataSettingsHelper.DatabaseIsInstalled())
            {
                _localizationService = EngineContext.Current.Resolve<ILocalizationService>();
                _workContext = EngineContext.Current.Resolve<IWorkContext>();
            }
        }

        //-->>

        //-->>

        public override string Layout
        {
            get
            {
                var layout = base.Layout;

                if(!string.IsNullOrEmpty(layout))
                {
                    var filename = Path.GetFileNameWithoutExtension(layout);
                    ViewEngineResult viewResult = System.Web.Mvc.ViewEngines.Engines.FindView(ViewContext.Controller.ControllerContext, filename, "");

                    if (viewResult.View != null && viewResult.View is RazorView)
                    {
                        layout = (viewResult.View as RazorView).ViewPath;
                    }
                }

                return layout;
            }
            set
            {
                base.Layout = value;
            }
        }

        //-->>

        //-->>



    }

    public abstract class WebViewPage : WebViewPage<dynamic>
    {

    }

}
