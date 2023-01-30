using LambdaApi.Application.Dto.Result;
using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace LambdaApi.Application.UseCases.Customer.GetGustomerById
{
    public class GetCustomerByIdRequestHandler : IRequestHandler<GetCustomerByIdRequest, Result<GetCustomerByIdResponse>>
    {
        public GetCustomerByIdRequestHandler()
        {

        }

        public async Task<Result<GetCustomerByIdResponse>> Handle(GetCustomerByIdRequest request, CancellationToken cancellationToken)
        {
            return "Algo";
        }
    }
}
