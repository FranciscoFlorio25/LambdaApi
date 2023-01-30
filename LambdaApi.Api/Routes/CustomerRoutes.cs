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
           

            builder.MapPost(PATH, async (IMediator mediator, AddCustomerRequest request) => await mediator.Send(request).ToHttpResult());

            builder.MapGet(PATH, async (IMediator mediator) => await mediator.Send(new GetCustomerRequest()).ToHttpResult());

            builder.MapGet(PATH + "/{customerId}", async (Guid CustomerId, IMediator mediator) => 
            await mediator.Send(new GetCustomerByIdRequest(CustomerId)).ToHttpResult());

            builder.MapDelete(PATH + "/{CustomerId}", async (Guid CustomerId, IMediator mediator) =>
            await mediator.Send(new DeleteCustomerRequest(CustomerId)).ToHttpResult());

            return builder;
        }
    }
}
