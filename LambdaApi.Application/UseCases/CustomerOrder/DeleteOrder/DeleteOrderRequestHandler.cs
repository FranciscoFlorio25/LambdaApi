using LambdaApi.Application.Dto.Result;
using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace LambdaApi.Application.UseCases.CustomerOrder.DeleteOrder
{
    public class DeleteOrderRequestHandler : AsyncRequestHandler<DeleteOrderRequest>
    {
        public DeleteOrderRequestHandler()
        {

        }

        protected override async Task<Result> Handle(DeleteOrderRequest request, CancellationToken cancellationToken)
        {
            return "Algo";
        }
    }
}
