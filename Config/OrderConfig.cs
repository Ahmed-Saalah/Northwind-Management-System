using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Northwind_Management_System.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind_Management_System.Config
{
    public class OrderConfig : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.HasKey(O => O.OrderId);

            builder.HasOne(O => O.Customer)
                .WithMany(C => C.Orders);

            builder.HasOne(O => O.Shipper)
                .WithMany(S => S.Orders);

            builder.HasOne(O => O.Employee)
                .WithMany(E => E.Orders);

            builder.HasMany(O => O.OrderDetails)
                .WithOne(OD => OD.Order);
        }
    }
}
