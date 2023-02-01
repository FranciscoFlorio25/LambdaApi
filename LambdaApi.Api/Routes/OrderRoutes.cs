using LambdaApi.Api.Extensions;
using LambdaApi.Application.UseCases.CustomerOrders.CreateOrder;
using LambdaApi.Application.UseCases.CustomerOrders.DeleteOrder;
using LambdaApi.Application.UseCases.CustomerOrders.GetCustomerOrder;
using MediatR;

namespace LambdaApi.Api.Routes
{
    public static class OrderRoutes
    {
        const string PATH = "/Customer/{CustomerId}";
        public static IEndpointRouteBuilder MapOrders(this IEndpointRouteBuilder builder)
        {

            builder.MapGet(PATH, async (Guid CustomerId, IMediator mediator) =>
            await mediator.Send(new GetCustomerOrderRequest(CustomerId)).ToHttpResult());

            builder.MapPost(PATH, async (CreateOrderRequest request,IMediator mediator) => await mediator.Send(request).ToHttpResult());

            builder.MapDelete(PATH + "/{OrderId}", async (Guid CustomerId, Guid OrderId, IMediator mediator) =>
            await mediator.Send(new DeleteOrderRequest(CustomerId, OrderId)).ToHttpResult());


            return builder;
        }
    }
}
