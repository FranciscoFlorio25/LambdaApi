using System.Net;
using Amazon.Lambda.Core;
using Amazon.Lambda.APIGatewayEvents;
using Microsoft.Extensions.DependencyInjection;
using System.Text.Json;
using LambdaApi.Extensions;
using LambdaApi.DI;
using LambdaApi.Application;
using LambdaApi.Configuration;
using LambdaApi.Services;
using LambdaApi.Infraestructure;

// Assembly attribute to enable the Lambda function's JSON input to be converted into a .NET class.
[assembly: LambdaSerializer(typeof(Amazon.Lambda.Serialization.SystemTextJson.DefaultLambdaJsonSerializer))]

namespace LambdaApi;

public class Function
{

    private IConfigurationService ConfigService { get; }

    public Function()
    {
        var service = new ServiceCollection();
        ConfigureServices(service);
        var serviceProvider = service.BuildServiceProvider();
        var ConfigService = serviceProvider.GetService<IConfigurationService>();
        service.AddApplication();
        service.AddInfraestructure(ConfigService.GetConfiguration());
    }

    private void ConfigureServices(ServiceCollection serviceCollection)
    {
        serviceCollection.AddTransient<IEnvironmentService, EnvironmentService>();
        serviceCollection.AddTransient<IConfigurationService, ConfigurationService>();
    }

    public async Task<APIGatewayHttpApiV2ProxyResponse> FunctionHandler(APIGatewayHttpApiV2ProxyRequest request, ILambdaContext context)
    {
        const string PATH = "/customer";
        var apiResponse = request.RequestContext.Http.Method switch
        {
            "GET" => async (IMediator mediator) => await mediator.Send (new GetCustomerRequest()).ToHttpResult(),
            "POST" => async (IMediator mediator) => await mediator.Send (new AddCustomerRequest(request)).ToHttpResult(),
            "DELETE" => async  (Guid CustomerId, IMediator mediator) => await mediator.Send(new DeleteCustomerRequest(CustomerId)).ToHttpResult(),
            _ => default
        };

        var response = new APIGatewayHttpApiV2ProxyResponse()
        {
            StatusCode = 200,
            Body = JsonSerializer.Serialize(apiResponse)
        };
        return response;
    }
}