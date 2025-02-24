using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OngsPet.Application.Services.AutoMapper;
using OngsPet.Application.Services.Cryptography;
using OngsPet.Application.UseCases.User.Register;

namespace OngsPet.Application
{
    public static class DependecyInjectionExtension
    {
        public static void AddApplication(this IServiceCollection services, IConfiguration configutarion)
        {
            AddAutoMapper(services);
            AddPasswordEncripter(services, configutarion);
            AddUseCases(services);
        }

        private static void AddUseCases(IServiceCollection services)
        {
            services.AddScoped<IRegisterUserUseCase, RegisterUserUseCase>();
        }

        private static void AddAutoMapper(IServiceCollection services)
        {
            var autoMapperConfig = new AutoMapper.MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new AutoMapping());

            }).CreateMapper();

            services.AddScoped(option => autoMapperConfig);
        }

        private static void AddPasswordEncripter(IServiceCollection services, IConfiguration configutarion)
        {
            var additionalKey = configutarion.GetSection("Settings:AdditionalKey").Value;
            services.AddScoped(option => new PasswordEncripter(additionalKey!));
        }
    }
}
