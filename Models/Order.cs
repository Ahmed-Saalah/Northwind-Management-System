﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind_Management_System.Models
{
    public class Order
    {
        public int OrderId { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime ShippedDate { get; set; }
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
        public Employee? Employee { get; set; }
        public Shipper? Shipper { get; set; }
        public ICollection<OrderDetail>? OrderDetails { get; set; }
    }
}
