using LambdaApi.Application.Data;
using LambdaApi.Application.Dto.Result;
using MediatR;
using Microsoft.EntityFrameworkCore;
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
        private readonly ICustomerContext _context;
        public GetCustomerRequestHandler(ICustomerContext context)
        {
            _context= context;
        }

        public async Task<Result<GetCustomerResponse>> Handle(GetCustomerRequest request, CancellationToken cancellationToken)
        {
            var customers= await _context.Customers.AsNoTracking().ToListAsync();
            if (!customers.Any() || customers == null)
            {
                return "there is no customers";
            }

            var ToGet = customers.Select(x =>
                new Customers(x.id,x.UserName,x.Email,x.Address,x.Phone)
            );

            return new GetCustomerResponse(ToGet);
        }
    }
}
