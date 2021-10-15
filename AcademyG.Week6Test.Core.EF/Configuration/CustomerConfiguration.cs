using AcademyG.Week6Test.Core.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace AcademyG.Week6Test.Core.EF.Configuration
{
    public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(c => c.CustomerCode)
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(c => c.FirstName)
                .HasMaxLength(30)
                .IsRequired();

            builder.Property(c => c.LastName)
                .HasMaxLength(30)
                .IsRequired();

            builder
                .HasMany(o => o.Orders)
                .WithOne(c => c.Customer);
        }
    }
}
