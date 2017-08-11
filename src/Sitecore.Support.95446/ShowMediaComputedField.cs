using Sitecore.ContentSearch;
using Sitecore.ContentSearch.ComputedFields;
using Sitecore.Data;
using Sitecore.Data.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sitecore.Support
{
    public class ShowMediaComputedField : AbstractComputedIndexField
    {
        private static ID[] defaultUnversionedMedia = { new ID("{D56DB3AA-7373-4651-837E-8D3977A0B544}"),
            new ID("{16692733-9A61-45E6-B0D4-4C0C06F8DD3C}"), new ID("{777F0C76-D712-46EA-9F40-371ACDA18A1C}"),
            new ID("{7BB0411F-50CD-4C21-AD8F-1FCDE7C3AFFE}"), new ID("{962B53C4-F93B-4DF9-9821-415C867B8903}"),
            new ID("{9867C0B9-A7BE-4D96-AD7E-4AD18109ED20}"), new ID("{F1828A2C-7E5D-4BBD-98CA-320474871548}"),
            new ID("{DAF085E8-602E-43A6-8299-038FF171349F}"), new ID("{E76ADBDF-87D1-4FCB-BA71-274F7DBF5670}"),
            new ID("{B60424A5-CE06-4C2E-9F49-A6D732F55D4B}"), new ID("{0603F166-35B8-469F-8123-E8D87BEDC171}"),
            new ID("{4F4A3A3B-239F-4988-98E1-DA3779749CBC}") };
        public override object ComputeFieldValue(IIndexable indexable)
        {
            Item indexableItem = indexable as SitecoreIndexableItem;
            if (indexableItem == null)
            {
                return null;
            }

            if (defaultUnversionedMedia.Contains(indexableItem.TemplateID))
            {

                foreach (var itemLanguage in indexableItem.Languages)
                {
                    var item = indexableItem.Database.GetItem(indexableItem.ID, itemLanguage);
                    if (item.Versions.Count > 0)
                    {
                        return (indexableItem.Language == itemLanguage) && indexableItem.Versions.IsLatestVersion();
                    }
                }
                return false;
            }
            return true;
        }
    }
}