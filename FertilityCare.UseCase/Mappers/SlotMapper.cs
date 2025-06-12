using FertilityCare.Domain.Entities;
using FertilityCare.UseCase.DTOs.Slots;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FertilityCare.UseCase.Mappers
{
    public static class SlotMapper
    {

        public static SlotDTO MapToSlotDTO(this Slot slot)
        {
            return new SlotDTO
            {
                SlotNumber = slot.SlotNumber,
                StartTime = slot.StartTime.ToString("HH:mm"),
                EndTime = slot.EndTime.ToString("HH:mm"),
                CreatedAt = slot.CreatedAt.ToString("dd/MM/yyyy HH:mm:ss"),
                UpdatedAt = slot.UpdatedAt?.ToString("dd/MM/yyyy HH:mm:ss"),
            };
        }

    }
}
