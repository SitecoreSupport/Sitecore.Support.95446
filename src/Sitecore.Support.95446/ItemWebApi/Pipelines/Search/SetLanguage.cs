using Sitecore.ContentSearch.Linq.Utilities;
using Sitecore.Diagnostics;
using Sitecore.ItemWebApi.Pipelines.Search;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sitecore.Support.ItemWebApi.Pipelines.Search
{
    public class SetLanguage : DefinitionBasedSearchProcessor
    {
        public override void Process(SearchArgs args)
        {
            Assert.ArgumentNotNull(args, "args");
            if (string.IsNullOrEmpty(args.LanguageName))
            {
                return;
            }

            var templatePredicate = PredicateBuilder.False<ConvertedSearchResultItem>();

            string[] childTemplatesIDs = { "d56db3aa73734651837e8d3977a0b544", "166927339a6145e6b0d44c0c06f8dd3c",
                "777f0c76d71246ea9f40371acda18a1c", "7bb0411f50cd4c21ad8f1fcde7c3affe",
                "962b53c4f93b4df99821415c867b8903", "9867c0b9a7be4d96ad7e4ad18109ed20",
                "f1828a2c7e5d4bbd98ca320474871548", "daf085e8602e43a68299038ff171349f",
                "e76adbdf87d14fcbba71274f7dbf5670", "e76adbdf87d14fcbba71274f7dbf5670",
                "0603f16635b8469f8123e8d87bedc171", "4f4a3a3b239f498898e1da3779749cbc" };

            templatePredicate = templatePredicate.Or(i => string.Compare(i.Language, args.LanguageName, StringComparison.InvariantCultureIgnoreCase) == 0);

            foreach (var tid in childTemplatesIDs)
            {
                templatePredicate = templatePredicate.Or(i => i.TemplateId.Equals(tid));
            }

            args.Queryable = args.Queryable.Where(templatePredicate);

            args.Queryable = args.Queryable.Where(i => i["_showMedia"] == "1");
        }
    }
}