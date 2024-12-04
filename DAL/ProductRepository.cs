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
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        public ProductRepository(NorthwindContext context) : base(context) { }

        public IEnumerable<Product> GetProductsWithCategory()
        {
            return _context.Products
                .Include(p => p.Category)
                .ToList();
        }
        public IEnumerable<Product> GetProductsWithSupplier()
        {
            return _context.Products
                .Include(p => p.Supplier)
                .ToList();
        }

        public IEnumerable<Category> GetCategories() 
        { 
            return _context.Categories.ToList();
        }
        public IEnumerable<Supplier> GetSuppliers()
        {
            return _context.Suppliers.ToList();
        }
    }
}
