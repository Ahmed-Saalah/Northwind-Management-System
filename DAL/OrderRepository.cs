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
    public class OrderRepository : Repository<Order>, IOrderRepository
    {
        public OrderRepository(NorthwindContext context) : base(context) { }

        public IEnumerable<Order> GetOrdersByCustomerId(string customerId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Order> GetOrdersWithDetails()
        {
            return _context.Orders
                .Include(o => o.OrderDetails)
                .ThenInclude(od => od.Product)
                .ToList();
        }

        public IEnumerable<Order> GetOrdersByCustomerId(int customerId)
        {
           return _context.Orders
               .Where(o => o.Customer.CustomerId == customerId)
               .ToList();
        }
    }
}
