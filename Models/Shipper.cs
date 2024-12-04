using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind_Management_System.Models
{
    public class Shipper
    {
        public int ShipperId { get; set; }
        public string CompanyName { get; set; }
        public string? Phone { get; set; }
        public ICollection<Order>? Orders { get; set; }
    }
}
