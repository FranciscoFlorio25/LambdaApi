using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LambdaApi.Domain.Entity
{
    public class Customer
    {
        public Customer(string userName, string email, string phone, string address)
        {
            UserName = userName;
            Email = email;
            Phone = phone;
            Address = address;
        }

        public Guid id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }

    }
}
