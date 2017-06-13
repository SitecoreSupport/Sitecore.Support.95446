using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sitecore.Support.Speak.Applications
{
    public class SelectMediaDialog : Sitecore.Speak.Applications.SelectMediaDialog
    {
        public override void Initialize()
        {
            base.Initialize();
            base.DataSource.Parameters["Language"] = String.Empty;
        }
    }
}