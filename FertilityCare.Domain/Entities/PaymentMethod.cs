using FertilityCare.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FertilityCare.Domain.Entities;

public class PaymentMethod
{
    public Guid Id { get; set; }

    public PaymentType Name { get; set; }

    public string? Description { get; set; }

    public bool IsActive { get; set; } = true;

}
