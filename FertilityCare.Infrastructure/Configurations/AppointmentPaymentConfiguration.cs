using FertilityCare.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FertilityCare.Infrastructure.Configurations;

public class AppointmentPaymentConfiguration : IEntityTypeConfiguration<AppointmentPayment>
{
    public void Configure(EntityTypeBuilder<AppointmentPayment> builder)
    {
        builder.ToTable("AppointmentPayment");

        builder.HasKey(p => p.Id);

        builder.Property(p => p.PaymentCode)
            .HasMaxLength(500);

        builder.Property(p => p.TransactionCode)
            .HasMaxLength(500);

        builder.Property(p => p.TotalAmount)
            .HasColumnType("decimal(18,2)");

        builder.Property(p => p.Note)
            .HasColumnType("ntext");

        builder.Property(p => p.GatewayResponseCode)
            .HasMaxLength(255);

        builder.Property(p => p.GatewayMessage)
            .HasMaxLength(500);

        builder.Property(p => p.SignedHash)
            .HasMaxLength(500);

        builder.Property(p => p.Status)
            .IsRequired();

        builder.Property(p => p.IsConfirmed)
            .HasDefaultValue(false);

        builder.Property(p => p.PaymentDate)
            .HasDefaultValueSql("GETDATE()");

        builder.Property(p => p.CreatedAt)
            .HasDefaultValueSql("GETDATE()");

        builder.HasOne(p => p.UserProfile)
            .WithMany()
            .HasForeignKey(p => p.UserProfileId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(p => p.Appointment)
            .WithMany()
            .HasForeignKey(p => p.AppointmentId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(p => p.PaymentMethod)
            .WithMany()
            .HasForeignKey(p => p.PaymentMethodId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}