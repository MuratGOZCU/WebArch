using YK.Web.Framework.Mvc.Models;

namespace YK.Web.Api.Models.Localization
{
    public class LanguageModel : BaseAppEntityModel
    {
        public string Name { get; set; }
        public string LanguageCulture { get; set; }
        public string UniqueSeoCode { get; set; }
        public string FlagImageFileName { get; set; }
        public bool Published { get; set; }
        public int DisplayOrder { get; set; }
    }
}