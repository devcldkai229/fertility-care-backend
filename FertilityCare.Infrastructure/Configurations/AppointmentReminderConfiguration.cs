using FertilityCare.Domain.Entities;
using FertilityCare.Domain.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FertilityCare.Infrastructure.Configurations;

public class AppointmentReminderConfiguration : IEntityTypeConfiguration<AppointmentReminder>
{
    public void Configure(EntityTypeBuilder<AppointmentReminder> builder)
    {
        builder.ToTable("AppointmentReminder");

        builder.HasKey(r => r.Id);

        builder.Property(r => r.ToEmailAddress)
            .HasMaxLength(255);

        builder.Property(r => r.ToPhoneNumber)
            .HasMaxLength(20);

        builder.Property(r => r.ReminderMethod)
            .HasMaxLength(100);

        builder.Property(r => r.IsSent)
            .HasDefaultValue(false);

        builder.Property(r => r.Status)
            .IsRequired();

        builder.Property(r => r.Note)
            .HasMaxLength(1000)
            .HasDefaultValue(string.Empty);

        builder.Property(r => r.CreatedAt)
            .HasDefaultValueSql("GETDATE()");

        builder.HasOne(r => r.Appointment)
            .WithMany()
            .HasForeignKey(r => r.AppointmentId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
