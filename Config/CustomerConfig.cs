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
    public class CustomerConfig : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.HasKey(x => x.CustomerId);

            //builder.Property(C => C.CompanyName)
            //    .IsRequired()
            //    .HasMaxLength(50);

            builder.Property(C => C.ContactName)
                .IsRequired()
                .HasMaxLength(50);

            //builder.Property(C => C.ContactTitle)
            //    .IsRequired()
            //    .HasMaxLength(50);

            builder.HasMany(C => C.Orders)
                .WithOne(O => O.Customer);
        }
    }
}
