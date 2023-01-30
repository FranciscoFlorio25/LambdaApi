using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace LambdaApi.Application.UseCases.Customer.AddCustomer
{
    public record AddCustomerResponse(string UserName, string Email, string Phone, string Addres, string Message);
}