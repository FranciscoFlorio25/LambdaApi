using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LambdaApi.Domain.Entity
{
    public class CustomerOrder
    {
        public CustomerOrder(Guid customerId, string productName, string productDescription, float productPrice)
        {
            CustomerId = customerId;
            ProductName = productName;
            ProductDescription = productDescription;
            ProductPrice = productPrice;
        }

        public Guid Id { get; set; }
        public Guid CustomerId { get; set; }
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
        public float ProductPrice { get; set; }
    }
}
