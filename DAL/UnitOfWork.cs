using Northwind_Management_System.Context;
using Northwind_Management_System.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind_Management_System.DAL
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly NorthwindContext _context;

        public UnitOfWork(NorthwindContext context)
        {
            _context = context;
            Products = new ProductRepository(_context);
            Categories = new CategoryRepository(_context);
            Orders = new OrderRepository(_context);
            Customers = new CustomerRepository(_context);
        }

        public IProductRepository Products { get; private set; }
        public ICategoryRepository Categories { get; private set; }
        public IOrderRepository Orders { get; private set; }
        public ICustomerRepository Customers { get; private set; }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}

