using YK.Core.Data;
using YK.Core.Domain.Localization;
using Microsoft.EntityFrameworkCore;

namespace YK.Data.Mapping.Localization
{
    public class LanguageMap : IEntityRegistrar
    {
        public void Register(ModelBuilder modelBuilder)
        {
            var entity = modelBuilder.Entity<Language>();

            entity.ToTable("Language");
            entity.HasKey(l => l.Id);
            entity.Property(l => l.Name).IsRequired().HasMaxLength(100);
            entity.Property(l => l.LanguageCulture).IsRequired().HasMaxLength(20);
            entity.Property(l => l.UniqueSeoCode).HasMaxLength(2);
            entity.Property(l => l.FlagImageFileName).HasMaxLength(50);
        }
    }
}