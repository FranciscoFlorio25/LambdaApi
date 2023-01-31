using LambdaApi.Application;
using LambdaApi.Configuration;
using LambdaApi.Infraestructure;
using LambdaApi.Services;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace LambdaApi.DI
{
    public class DependencyResolver
    {
        public IServiceProvider ServiceProvider { get; }
        public string CurrentDirectory { get; set; }
        public Action<IServiceCollection> RegisterServices { get;  }
        public DependencyResolver()
        {
            // Set up Dependency Injection
            IServiceCollection services = new ServiceCollection();
            //ConfigureServices(services);
            ServiceProvider = services.BuildServiceProvider();

        }
/*
        private void ConfigureServices(IServiceCollection services)
        {
            // Register env and config services
            
            services.AddTransient<IEnvironmentService, EnvironmentService>();
            services.AddTransient<IConfigurationService, ConfigurationService>
            (provider => new ConfigurationService(provider.GetService<IEnvironmentService>())
            {
                CurrentDirectory = CurrentDirectory
            });
            RegisterServices?.Invoke(services);
        }
*/
    }   

}