using AutoMapper;
using Libe.AccountMicroservice.Business.Mapper;

namespace Libe.AccountMicroservice.Api.AppSetup
{
    public static class AutoMapperConfigurator
    {
        public static void ConfigureAutoMapper(this IServiceCollection services)
        {
            var mapperConfig = new MapperConfiguration(ms => ms.AddProfile(new AccountMicroserviceMapProfile()));

            IMapper mapper = mapperConfig.CreateMapper();
            services.AddSingleton(mapper);
        }
    }
}
