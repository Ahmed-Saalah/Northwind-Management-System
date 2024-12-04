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
    public class OrderDetailConfig : IEntityTypeConfiguration<OrderDetail>
    {
        public void Configure(EntityTypeBuilder<OrderDetail> builder)
        {
            builder.HasKey(OD => new { OD.OrderId, OD.ProductId });

            builder.Property(OD => OD.UnitPrice)
                .IsRequired();

            builder.Property(OD => OD.Quantity)
                .IsRequired();

            builder.Property(OD => OD.Discount)
                .HasColumnType("decimal(5, 2)") 
                .IsRequired();

            builder.HasOne(OD => OD.Order)
                .WithMany(O => O.OrderDetails)
                .HasForeignKey(OD => OD.OrderId);

            builder.HasOne(OD => OD.Product)
                .WithMany(P => P.OrderDetails);
        }
    }
}
