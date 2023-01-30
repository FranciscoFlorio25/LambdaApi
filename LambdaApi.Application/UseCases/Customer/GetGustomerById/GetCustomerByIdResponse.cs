using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace LambdaApi.Application.UseCases.Customer.GetGustomerById
{
    public record Order (Guid OrderId, string orderName, string OrderDescription, float orderPrice);
    public record GetCustomerByIdResponse(string UserName, string Phone, string Email, string Address, IEnumerable<Order>? Orders);
}