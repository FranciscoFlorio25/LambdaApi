using LambdaApi.Api.Extensions;
using LambdaApi.Application.UseCases.Customer.AddCustomer;
using LambdaApi.Application.UseCases.Customer.DeleteCustomer;
using LambdaApi.Application.UseCases.Customer.GetCustomer;
using LambdaApi.Application.UseCases.Customer.GetGustomerById;
using MediatR;
using Microsoft.AspNetCore.Routing;

namespace LambdaApi.Api.Routes
{
    public static class CustomerRoutes
    {
        const string PATH = "/customer";

        public static IEndpointRouteBuilder MapCustomer(this IEndpointRouteBuilder builder)
        {
            var group = builder.MapGroup(PATH);

            group.MapPost("", async (IMediator mediator, AddCustomerRequest request) => await mediator.Send(request).ToHttpResult());

            group.MapGet("", async (IMediator mediator) => await mediator.Send(new GetCustomerRequest()).ToHttpResult());

            group.MapGet("{customerId}", async (Guid CustomerId, IMediator mediator) => 
            await mediator.Send(new GetCustomerByIdRequest(CustomerId)).ToHttpResult());

            group.MapDelete("{CustomerId}", async (Guid CustomerId, IMediator mediator) =>
            await mediator.Send(new DeleteCustomerRequest(CustomerId)).ToHttpResult());

            return builder;
        }
    }
}
