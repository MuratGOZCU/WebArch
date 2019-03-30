using YK.Core.Caching;
using YK.Core.Data;
using YK.Core.Domain.Localization;
using YK.Data;

namespace YK.Services.Localization
{
    public class LanguageService : ServiceBase<Language>, ILanguageService
    {
        #region Constants

        private const string CATEGORIES_BY_ID_KEY = "Nop.category.id-{0}";

        #endregion

        #region Fields

        private readonly IRepository<Language> _languageRepository;
        private readonly ICacheManager _cacheManager;

        #endregion

        public LanguageService(IRepository<Language> languageRepository, ICacheManager cacheManager) : base(languageRepository)
        {
            _cacheManager = cacheManager;
            _languageRepository = languageRepository;
        }

        public override Language GetById(int entityId)
        {
   

            if (entityId == 0)
                return null;

            var key = string.Format(CATEGORIES_BY_ID_KEY, entityId);
            return _cacheManager.Get(key, () => _languageRepository.GetById(entityId));
        }

        

    }
}
