using YK.Services.Localization;
using YK.Web.Api.Models.Localization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using YK.Core.Domain.Localization;

namespace YK.Web.Api.Controllers
{
    public class LanguageController : BaseAutoServiceController<Language, LanguageModel, ILanguageService>
    {
        public LanguageController(ILanguageService service) : base(service)
        {

        }

    }
}
