using Northwind_Management_System.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind_Management_System
{
    public class Category
    {
        public int CategoryId { get; set; }


        public string CategoryName { get; set; }
        public string? Description { get; set; }
        public ICollection<Product>? Products { get; set; }
    }
}
