using FertilityCare.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FertilityCare.Infrastructure.Configurations;

public class EmbryoTransferConfiguration : IEntityTypeConfiguration<EmbryoTransfer>
{
    public void Configure(EntityTypeBuilder<EmbryoTransfer> builder)
    {
        builder.ToTable("EmbryoTransfer");

        builder.HasKey(e => e.Id);

        builder.Property(e => e.EmbryoGrade)
            .HasMaxLength(255)
            .IsRequired();

        builder.Property(e => e.IsViable)
            .IsRequired();

        builder.Property(e => e.TransferType)
            .IsRequired();

        builder.Property(e => e.EmbryoStatus)
            .IsRequired();

        builder.Property(e => e.TransferDate)
            .IsRequired();

        builder.Property(e => e.CreatedAt)
            .HasDefaultValueSql("GETDATE()");

        builder.HasOne(e => e.Appointment)
            .WithMany()
            .HasForeignKey(e => e.AppointmentId)
            .OnDelete(DeleteBehavior.SetNull);

        builder.HasOne(e => e.Order)
            .WithMany(o => o.Embryos)
            .HasForeignKey(e => e.OrderId);
    }
}
