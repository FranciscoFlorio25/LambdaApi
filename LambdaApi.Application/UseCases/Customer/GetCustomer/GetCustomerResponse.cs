using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace LambdaApi.Application.UseCases.Customer.GetCustomer
{
    public record Customers (Guid Id, string UserName, string Email, string Address, string Phone);
    public record GetCustomerResponse(IEnumerable<Customers> Customers);
}