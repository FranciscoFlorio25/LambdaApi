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

namespace LambdaApi.Application.UseCases.CustomerOrders.GetCustomerOrder
{
    public class GetCustomerOrderRequestHandler : IRequestHandler<GetCustomerOrderRequest, Result<GetCustomerOrderResponse>>
    {
        private readonly ICustomerContext _context;
        public GetCustomerOrderRequestHandler(ICustomerContext context)
        {
            _context = context;
        }

        public async Task<Result<GetCustomerOrderResponse>> Handle(GetCustomerOrderRequest request, CancellationToken cancellationToken)
        {
            var customer = await _context.Customers.AsNoTracking().FirstOrDefaultAsync(x => x.id == request.Customer);

            if (customer == null)
            {
                return "customer doesnt exist";
            }

            var customerOrders = _context.CustomerOrders.Select(x =>
                 new Order(x.Id, x.ProductName, x.ProductDescription, x.ProductPrice));
            if (!customerOrders.Any() && customerOrders == null)
            {
                return "The customer dosent have orders";
            }

            return new GetCustomerOrderResponse(customerOrders);
        }
    }
}
