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

namespace LambdaApi.Application.UseCases.CustomerOrders.DeleteOrder
{
    public class DeleteOrderRequestHandler : AsyncRequestHandler<DeleteOrderRequest>
    {
        private readonly ICustomerContext _context; 
        public DeleteOrderRequestHandler(ICustomerContext context)
        {
            _context= context;
        }

        protected override async Task<Result> Handle(DeleteOrderRequest request, CancellationToken cancellationToken)
        {
            var customer = await _context.Customers.AsNoTracking().FirstOrDefaultAsync(x => x.id == request.CustomerId);

            if (customer == null)
            {
                return "customer doesnt exist";
            }

            var order = await _context.CustomerOrders.AsNoTracking().FirstOrDefaultAsync(x => x.Id == request.OrderId);

            if (order == null)
            {
                return "order was not found";
            }

            _context.CustomerOrders.Remove(order);
            await _context.SaveChangesAsync(cancellationToken);

            return "Order was deleted";
        }
    }
}
