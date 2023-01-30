using System.Net;
using Amazon.Lambda.Core;
using Amazon.Lambda.APIGatewayEvents;
using Microsoft.Extensions.DependencyInjection;
using LambdaApi.Infraestructure;
using LambdaApi.Application;
using Microsoft.Extensions.Configuration;
// Assembly attribute to enable the Lambda function's JSON input to be converted into a .NET class.
[assembly: LambdaSerializer(typeof(Amazon.Lambda.Serialization.SystemTextJson.DefaultLambdaJsonSerializer))]

namespace LambdaApi;

public class Function
{
    readonly IServiceProvider _serviceProvider;
    
    public Function()
    {
        Console.WriteLine("Setting up the DI container");
        var serviceCollection = new ServiceCollection();
        Console.WriteLine("Adding a scoped service");
        //serviceCollection.AddInfraestructure();
        serviceCollection.AddApplication();
        _serviceProvider = serviceCollection.BuildServiceProvider();
    }

    public string FunctionHandler(string input, ILambdaContext context)
    {

        return "Cereal";
    }
}