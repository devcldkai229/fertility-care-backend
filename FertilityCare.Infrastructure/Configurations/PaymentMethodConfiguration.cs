using FertilityCare.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FertilityCare.Infrastructure.Configurations;

public class PaymentMethodConfiguration : IEntityTypeConfiguration<PaymentMethod>
{
    public void Configure(EntityTypeBuilder<PaymentMethod> builder)
    {
        builder.ToTable("PaymentMethod");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id).HasDefaultValueSql("NEWID()");

        builder.Property(x => x.Name).HasColumnType("NVARCHAR(100)").IsRequired();

        builder.Property(x => x.Description).HasColumnType("NVARCHAR(MAX)");

        builder.Property(x => x.IsActive).HasDefaultValue(true);
    }
}
