using LambdaApi.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LambdaApi.Application.Data
{
    public interface ICustomerContext
    {
        DbSet<Customer> Customers { get; }
        DbSet<CustomerOrder> CustomerOrders { get; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
