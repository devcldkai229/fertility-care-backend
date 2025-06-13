using FertilityCare.UseCase.DTOs.DoctorSchedules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FertilityCare.UseCase.DTOs.Slots
{
    public class SlotWithScheduleDTO
    {
        public long SlotId { get; set; }
        public string StartTime { get; set; }
        public string EndTime { get; set; }

        // Đây là danh sách ID của các DoctorSchedule trong Slot
        public List<long> DoctorScheduleIds { get; set; } = new();
    }
}

