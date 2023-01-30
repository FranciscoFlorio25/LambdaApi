using LambdaApi.Application.Dto.Result;
using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace LambdaApi.Application.UseCases.Customer.AddCustomer
{
    public record AddCustomerRequest(string UserName, string Email, string Phone, string Addres ) : IRequest<Result<AddCustomerResponse>>;

}
