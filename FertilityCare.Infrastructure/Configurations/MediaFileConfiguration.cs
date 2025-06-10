using FertilityCare.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FertilityCare.Infrastructure.Configurations;

public class MediaFileConfiguration : IEntityTypeConfiguration<MediaFile>
{
    public void Configure(EntityTypeBuilder<MediaFile> builder)
    {
        builder.ToTable("MediaFile");

        builder.HasKey(m => m.Id);

        builder.Property(m => m.PublicId)
            .HasMaxLength(255);

        builder.Property(m => m.Url)
            .HasMaxLength(500);

        builder.Property(m => m.SecureUrl)
            .HasMaxLength(500);

        builder.Property(m => m.Folder)
            .HasMaxLength(255);

        builder.Property(m => m.FileName)
            .HasMaxLength(255);

        builder.Property(m => m.Format)
            .HasMaxLength(50);

        builder.Property(m => m.Size)
            .IsRequired();

        builder.Property(m => m.Width)
            .IsRequired(false);

        builder.Property(m => m.Height)
            .IsRequired(false);

        builder.Property(m => m.Duration)
            .HasColumnType("decimal(10,2)")
            .IsRequired(false);

        builder.Property(m => m.Tags)
            .HasMaxLength(1000)
            .IsRequired();

        builder.Property(m => m.OwnerId)
            .IsRequired(false);

        builder.Property(m => m.UploadedAt)
            .HasDefaultValueSql("GETDATE()");
    }
}
