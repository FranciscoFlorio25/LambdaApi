using LambdaApi.Application.Dto.Result;
using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace LambdaApi.Application.UseCases.CustomerOrders.CreateOrder
{
    public record CreateOrderRequest(Guid CustomerId, string ProdcutName, string ProductDescription, float ProductoPrice) : IRequest<Result<CreateOrderResponse>>;

}
