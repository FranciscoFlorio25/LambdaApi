using LambdaApi.Application.Data;
using LambdaApi.Application.Dto.Result;
using LambdaApi.Domain.Entity;
using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace LambdaApi.Application.UseCases.Customer.AddCustomer
{
    public class AddCustomerRequestHandler : IRequestHandler<AddCustomerRequest, Result<AddCustomerResponse>>
    {
        private readonly ICustomerContext _context;
        public AddCustomerRequestHandler(ICustomerContext contesxt)
        {
            _context= contesxt;
        }

        public async Task<Result<AddCustomerResponse>> Handle(AddCustomerRequest request, CancellationToken cancellationToken)
        {
            var costumer = new Domain.Entity.Customer (request.UserName, request.Email, request.Phone, request.Addres);

            try
            {
                await _context.Customers.AddAsync (costumer);
                await _context.SaveChangesAsync(cancellationToken);
            }
            catch (Exception ex)
            {
                return "Customer coudnt be added error: " + ex.Message;
            }

            return new AddCustomerResponse(request.UserName, request.Email, request.Phone, request.Addres, "Customer added succefully");
        }
    }
}
