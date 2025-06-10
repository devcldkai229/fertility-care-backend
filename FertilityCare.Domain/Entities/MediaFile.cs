using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FertilityCare.Domain.Entities;

public class MediaFile
{

    public Guid Id { get; set; }

    public string? PublicId { get; set; }

    public string? Url { get; set; }

    public string? SecureUrl { get; set; }

    public string? Folder { get; set; }

    public string? FileName { get; set; }

    public string? Format { get; set; }

    public long Size { get; set; }

    public int? Width { get; set; }

    public int? Height { get; set; }

    public decimal? Duration { get; set; } 

    public string Tags { get; set; }

    public Guid? OwnerId { get; set; }

    public DateTime UploadedAt { get; set; } = DateTime.Now;
}
