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
    public class ShipperConfig : IEntityTypeConfiguration<Shipper>
    {
        public void Configure(EntityTypeBuilder<Shipper> builder)
        {
            builder.HasKey(S => S.ShipperId);

            builder.Property(S => S.CompanyName)
                .IsRequired()
                .HasMaxLength(50);

            builder.HasMany(S => S.Orders)
                .WithOne(O => O.Shipper);
        }
    }
}
