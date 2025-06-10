using FertilityCare.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FertilityCare.Domain.Entities;

public class AppointmentPayment
{
    public Guid Id { get; set; }

    public Guid UserProfileId { get; set; }

    public virtual UserProfile UserProfile { get; set; }

    public Guid AppointmentId { get; set; }

    public virtual Appointment Appointment { get; set; }

    public string? PaymentCode { get; set; } 

    public decimal TotalAmount { get; set; }

    public Guid PaymentMethodId { get; set; }

    public virtual PaymentMethod PaymentMethod { get; set; }

    public string? TransactionCode { get; set; } 

    public DateTime PaymentDate { get; set; } = DateTime.Now;

    public PaymentStatus Status { get; set; }

    public string? Note { get; set; }

    public string? GatewayResponseCode { get; set; } 

    public string? GatewayMessage { get; set; }

    public string? SignedHash { get; set; }

    public bool IsConfirmed { get; set; } = false;

    public DateTime? ConfirmedAt { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.Now;

    public DateTime? UpdatedAt { get; set; }
}

