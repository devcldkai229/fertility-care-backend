using FertilityCare.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FertilityCare.Domain.Entities;

public class AppointmentReminder
{
    public long Id { get; set; }

    public Guid AppointmentId { get; set; }

    public virtual Appointment Appointment { get; set; }

    public string? ToEmailAddress { get; set; }

    public string? ToPhoneNumber { get; set; }

    public DateTime? ReminderDate { get; set; }

    public string? ReminderMethod { get; set; }

    public bool IsSent { get; set; } = false;

    public ReminderStatus Status { get; set; } = ReminderStatus.Pending;

    public string? Note { get; set; } = "";

    public DateTime CreatedAt { get; set; } = DateTime.Now;

    public DateTime? UpdatedAt { get; set; }

}
