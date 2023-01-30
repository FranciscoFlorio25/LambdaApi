using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace LambdaApi.Application.UseCases.GetCustomerOrder
{
    public record Order (Guid CustomerId, string OrderName, string OrderDescription, float OrderPrice);
    public record GetCustomerOrderResponse(IEnumerable<Order> Orders);
}