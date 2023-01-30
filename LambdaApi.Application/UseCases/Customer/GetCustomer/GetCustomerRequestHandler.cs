using LambdaApi.Application.Dto.Result;
using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace LambdaApi.Application.UseCases.Customer.GetCustomer
{
    public class GetCustomerRequestHandler : IRequestHandler<GetCustomerRequest, Result<GetCustomerResponse>>
    {
        public GetCustomerRequestHandler()
        {

        }

        public async Task<Result<GetCustomerResponse>> Handle(GetCustomerRequest request, CancellationToken cancellationToken)
        {
            return "algo";
        }
    }
}
