using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind_Management_System.DAL
{
    public interface ICategoryRepository : IRepository<Category>
    {
        IEnumerable<Category> GetCategoriesWithProducts();
    }
}
