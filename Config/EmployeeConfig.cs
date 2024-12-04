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
    public class EmployeeConfig : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.HasKey(E => E.EmployeeId);

            builder.Property(E => E.LastName)
                .IsRequired()
                .HasMaxLength(50);
            builder.Property(E => E.FirstName)
                .IsRequired()
                .HasMaxLength(50);
            builder.Property(E => E.Title)
                .IsRequired()
                .HasMaxLength(50);

            builder.HasOne(E => E.Manager)
                .WithMany(M => M.Subordinates)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.NoAction);

             builder.HasMany(E => E.Orders)
                .WithOne(E => E.Employee)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.NoAction);
        }

    }
}
