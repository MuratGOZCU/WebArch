using YK.Core.Domain.Localization;
using YK.Core.Mapper;
using YK.Web.Api.Models.Localization;
using AutoMapper;

namespace YK.Web.Api.Infrastructure.Mapper
{
    public class AppMapperConfiguration : Profile, IMapperProfile
    {
        public int Order => 0;

        public AppMapperConfiguration()
        {
            //language
            CreateMap<Language, LanguageModel>()
                .ForMember(dest => dest.CustomProperties, mo => mo.Ignore());
            CreateMap<LanguageModel, Language>();
        }
    }
}
