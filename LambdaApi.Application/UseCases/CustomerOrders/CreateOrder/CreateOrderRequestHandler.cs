using LambdaApi.Application.Data;
using LambdaApi.Application.Dto.Result;
using LambdaApi.Domain.Entity;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace LambdaApi.Application.UseCases.CreateOrder
{
    public class CreateOrderRequestHandler : IRequestHandler<CreateOrderRequest, Result<CreateOrderResponse>>
    {
        private readonly ICustomerContext _context;
        public CreateOrderRequestHandler(ICustomerContext context)
        {
            _context = context;
        }

        public async Task<Result<CreateOrderResponse>> Handle(CreateOrderRequest request, CancellationToken cancellationToken)
        {
            var customer = await _context.Customers.AsNoTracking().FirstOrDefaultAsync(x => x.id == request.CustomerId);

            if (customer == null)
            {
                return "customer doesnt exist";
            }

            CustomerOrder newOrder = new CustomerOrder(request.CustomerId, request.ProdcutName,request.ProductDescription,request.ProductoPrice);

            try
            {
                await _context.CustomerOrders.AddAsync(newOrder);
                await _context.SaveChangesAsync(cancellationToken);
            }
            catch(Exception ex)
            {
                return "Order coudent be added error: " + ex.Message;
            }

            return new CreateOrderResponse(request.CustomerId,request.ProdcutName,request.ProductDescription,request.ProductoPrice);
        }
    }
}
