using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FertilityCare.UseCase.DTOs.PrescriptionItem;
using FertilityCare.UseCase.DTOs.Prescriptions;

namespace FertilityCare.UseCase.Interfaces.Services
{
    public interface IPrescriptionItemService
    {
        Task<IEnumerable<PrescriptionItemDTO>> FindAllPRscriptionItemByPrescriptionIdAsync(Guid prescriptionId);
    }
}
