using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FertilityCare.Domain.Entities;
using FertilityCare.UseCase.DTOs.TreatmentServices;
using FertilityCare.UseCase.DTOs.TreatmentStep;

namespace FertilityCare.UseCase.Mappers
{
    public static class TreatmentServiceMapper
    {
        public static TreatmentServiceDTO MapToTreatmentServiceDTO(this TreatmentService treatmentServices)
        {
            return new TreatmentServiceDTO
            {
                Id = treatmentServices.Id,
                Name = treatmentServices.Name,
                Description = treatmentServices.Description,
                Duration = treatmentServices.Duration,
                SuccessRate = treatmentServices.SuccessRate,
                RecommendedFor = treatmentServices.RecommendedFor,
                Contraindications = treatmentServices.Contraindications,
                CreatedAt = treatmentServices.CreatedAt.ToString("dd/MM/yyyy HH:mm:ss"),
                UpdatedAt = treatmentServices.UpdatedAt?.ToString("dd/MM/yyyy HH:mm:ss"),
                TreatmentSteps = treatmentServices.TreatmentSteps?.Select(x => x.MapToTreatmentStepDTO()).ToList()

            };
        }
    }
}
