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

namespace LambdaApi.Application.UseCases.Customer.DeleteCustomer
{
    public class DeleteCustomerRequestHandler : AsyncRequestHandler<DeleteCustomerRequest>
    {
        private readonly ICustomerContext _context;
        public DeleteCustomerRequestHandler(ICustomerContext context)
        {
            _context= context;
        }

        protected override async Task<Result> Handle(DeleteCustomerRequest request, CancellationToken cancellationToken)
        {
            var customer = await _context.Customers.FirstOrDefaultAsync(x => x.id == request.CustomerId);

            if(customer == null)
            {
                return "Customer not found";
            }
            try
            {
                var products = await _context.CustomerOrders.Where(x => x.CustomerId == customer.id).ToListAsync();
                _context.CustomerOrders.RemoveRange(products);
                _context.Customers.Remove(customer);
            }
            catch(Exception ex)
            {
                return "Customer coudent be deleted error: " + ex.Message;
            }


            return "User Succefully deleted";
        }
    }
}
