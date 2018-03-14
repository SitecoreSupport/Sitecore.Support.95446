using Sitecore.ContentSearch;
using Sitecore.Data.Items;
using Sitecore.Diagnostics;
using Sitecore.Events;
using System;
using Sitecore.ContentSearch.Maintenance;

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

            IndexCustodian.Refresh(ContentSearchManager.GetIndex("sitecore_" + item.Database.Name + "_index"),
                (SitecoreIndexableItem) item);
        }
    }
}