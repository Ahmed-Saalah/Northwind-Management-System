using Microsoft.EntityFrameworkCore;
using Northwind_Management_System.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind_Management_System.DAL
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        public CategoryRepository(NorthwindContext context) : base(context) { }

        public IEnumerable<Category> GetCategoriesWithProducts()
        {
            return _context.Categories
                .Include(c => c.Products)
                .ToList();
        }

        public Category GetCategoriesByIdWithProducts(int id)
        {
            return _context.Categories
                .Include(c => c.Products)
                .FirstOrDefault(C => C.CategoryId == id);
        }
    }
}
