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
    public class CategoryConfig  : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasKey(C => C.CategoryId);
            builder.Property(C => C.CategoryName)
                .IsRequired();
            builder.HasMany(C => C.Products)
                .WithOne(P => P.Category);
        }
    }
}
