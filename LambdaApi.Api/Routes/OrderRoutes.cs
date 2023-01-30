using LambdaApi.Api.Extensions;
using LambdaApi.Application.UseCases.CreateOrder;
using LambdaApi.Application.UseCases.CustomerOrders.DeleteOrder;
using LambdaApi.Application.UseCases.GetCustomerOrder;
using MediatR;

namespace LambdaApi.Api.Routes
{
    public static class OrderRoutes
    {
        const string PATH = "/Customer/{CustomerId}";
        public static IEndpointRouteBuilder MapOrders(this IEndpointRouteBuilder builder)
        {
            var group = builder.MapGroup(PATH);

            group.MapGet("", async (Guid CustomerId, IMediator mediator) =>
            await mediator.Send(new GetCustomerOrderRequest(CustomerId)).ToHttpResult());

            group.MapPost("", async (CreateOrderRequest request,IMediator mediator) => await mediator.Send(request).ToHttpResult());

            group.MapDelete("{OrderId}", async (Guid CustomerId, Guid OrderId, IMediator mediator) =>
            await mediator.Send(new DeleteOrderRequest(CustomerId, OrderId)).ToHttpResult());


            return builder;
        }
    }
}
