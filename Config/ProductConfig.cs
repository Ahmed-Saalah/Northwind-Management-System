using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Northwind_Management_System.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind_Management_System.Config
{
    public class ProductConfig : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder) 
        {
            builder.HasKey(P => P.ProductId);
            builder.Property(P => P.ProductName)
                .IsRequired()
                .HasMaxLength(50);

            builder.HasOne(P => P.Category)
                .WithMany(C => C.Products);

            builder.HasOne(P => P.Supplier)
                .WithMany(S => S.Products);
        }
    }
}
