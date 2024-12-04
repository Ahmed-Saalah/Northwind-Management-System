using Microsoft.EntityFrameworkCore;
using Northwind_Management_System.Context;
using Northwind_Management_System.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind_Management_System.DAL
{
    public class CustomerRepository : Repository<Customer>, ICustomerRepository
    {
        public CustomerRepository(NorthwindContext context) : base(context) { }

        public IEnumerable<Customer> GetCustomersWithOrders()
        {
            return _context.Customers
                .Include(c => c.Orders)
                .ToList();
        }
    }
}
