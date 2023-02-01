using System.Net;
using Amazon.Lambda.Core;
using Amazon.Lambda.APIGatewayEvents;
using Microsoft.Extensions.DependencyInjection;
using System.Text.Json;
using LambdaApi.Application;
using LambdaApi.Configuration;
using LambdaApi.Services;
using LambdaApi.Infraestructure;
using System;
using MediatR;
using LambdaApi.Application.UseCases.Customer.GetCustomer;
using LambdaApi.Application.UseCases.Customer.AddCustomer;

// Assembly attribute to enable the Lambda function's JSON input to be converted into a .NET class.
[assembly: LambdaSerializer(typeof(Amazon.Lambda.Serialization.SystemTextJson.DefaultLambdaJsonSerializer))]

namespace LambdaApi
{
    public class Function
    {
        public IConfigurationService ConfigService { get; }
        readonly IServiceProvider _serviceProvider;

        public Function()
        {
            var service = new ServiceCollection();
            ConfigureServices(service);
            _serviceProvider = service.BuildServiceProvider();
            

            ConfigService = _serviceProvider.GetService<IConfigurationService>();

            service.AddApplication();
            service.AddInfraestructure(ConfigService.GetConfiguration());
        }

        private void ConfigureServices(IServiceCollection service)
        {
            
            service.AddTransient<IEnvironmentService, EnvironmentService>();
            service.AddTransient<IConfigurationService, ConfigurationService>();

        }

        public async Task<APIGatewayHttpApiV2ProxyResponse> FunctionHandler( ILambdaContext context)
        {
            var mediator = _serviceProvider.GetService<IMediator>();

            var apiResponse = await mediator.Send(new GetCustomerRequest());

            var response = new APIGatewayHttpApiV2ProxyResponse()
            {
                StatusCode = 200,
                Body = JsonSerializer.Serialize(apiResponse)
            };
            return response;
        }
    }
}

