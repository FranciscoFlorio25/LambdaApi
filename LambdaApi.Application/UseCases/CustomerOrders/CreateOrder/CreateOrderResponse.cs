using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace LambdaApi.Application.UseCases.CustomerOrders.CreateOrder
{
    public record CreateOrderResponse(Guid CustomerId, string ProdcutName, string ProductDescription, float ProductoPrice);
}