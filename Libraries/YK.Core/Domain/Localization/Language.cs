namespace YK.Core.Domain.Localization
{
    public class Language : BaseEntity
    {
        public string Name { get; set; }

        public string LanguageCulture { get; set; }

        public string UniqueSeoCode { get; set; }

        public string FlagImageFileName { get; set; }

        public bool Published { get; set; }

        public int DisplayOrder { get; set; }   
    }
}