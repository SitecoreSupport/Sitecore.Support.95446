using Sitecore.ContentSearch;
using Sitecore.Data.Items;
using Sitecore.Diagnostics;
using Sitecore.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sitecore.Support
{
    public class ShowMediaComputedFieldEventHandler
    {
        protected void OnVersionChange(object sender, EventArgs args)
        {
            if (args == null)
            {
                return;
            }
            Item item = Event.ExtractParameter(args, 0) as Item;

            Assert.IsNotNull(item, "No item in parameters");

            ContentSearchManager.GetIndex("sitecore_" + item.Database.Name + "_index").Refresh((SitecoreIndexableItem)item);
        }
    }
}