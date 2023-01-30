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

namespace LambdaApi.Application.UseCases.Customer.GetGustomerById
{
    public class GetCustomerByIdRequestHandler : IRequestHandler<GetCustomerByIdRequest, Result<GetCustomerByIdResponse>>
    {
        private readonly ICustomerContext _context;
        public GetCustomerByIdRequestHandler(ICustomerContext context)
        {
            _context= context;
        }

        public async Task<Result<GetCustomerByIdResponse>> Handle(GetCustomerByIdRequest request, CancellationToken cancellationToken)
        {
            var customer = await _context.Customers.AsNoTracking().FirstOrDefaultAsync(x => x.id == request.CustomerId);

            if (customer == null)
            {
                return "User not found";
            }

            var customerOrders = _context.CustomerOrders.Select(x =>
             new Order(x.Id, x.ProductName, x.ProductDescription, x.ProductPrice));


            return new GetCustomerByIdResponse(customer.UserName,customer.Phone,customer.Email,customer.Address,customerOrders);

        }
    }
}
