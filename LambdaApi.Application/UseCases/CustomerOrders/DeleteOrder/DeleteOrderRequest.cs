using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace LambdaApi.Application.UseCases.CustomerOrders.DeleteOrder
{
    public record DeleteOrderRequest(Guid CustomerId, Guid OrderId) : IRequest;

}
