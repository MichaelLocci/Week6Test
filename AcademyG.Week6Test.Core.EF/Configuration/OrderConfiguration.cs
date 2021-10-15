using AcademyG.Week6Test.Core.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace AcademyG.Week6Test.Core.EF.Configuration
{
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.HasKey(o => o.Id);

            builder.Property(o => o.OrderData)
                .IsRequired();

            builder.Property(o => o.OderCode)
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(o => o.ProductCode)
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(o => o.Import)
                .IsRequired();

            builder.Property(o => o.CustomerId)
                .IsRequired();

            builder
                .HasOne(c => c.Customer)
                .WithMany(o => o.Orders);
        }
    }
}
