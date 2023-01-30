using LambdaApi.Api.Routes;
using LambdaApi.Application;
using LambdaApi.Infraestructure;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);


// Add AWS Lambda support. When application is run in Lambda Kestrel is swapped out as the web server with Amazon.Lambda.AspNetCoreServer. This
// package will act as the webserver translating request and responses between the Lambda event source and ASP.NET Core.
builder.Services.AddAWSLambdaHosting(LambdaEventSource.RestApi);
builder.Services.AddAuthorization();
builder.Services.AddApplication();
builder.Services.AddInfraestructure(builder.Configuration);

var app = builder.Build();

app.UseHttpsRedirection();
app.MapCustomer();
app.MapOrders();
app.UseAuthorization();


app.Run();
