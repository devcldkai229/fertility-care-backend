using FertilityCare.Infrastructure.Identity;
using FertilityCare.Shared.Exceptions;
using FertilityCare.UseCase.DTOs.Patients;
using FertilityCare.UseCase.Interfaces.Repositories;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FertilityCare.Infrastructure.Services
{
    public interface IPatientSecretService
    {
        Task<PatientSecretInfo> GetPatientByUserIdAsync(string userId);

    }

    public class PatientSecretService : IPatientSecretService
    {
        private readonly IPatientRepository _patientRepository;

        private readonly IUserProfileRepository _profileRepository;

        private readonly UserManager<ApplicationUser> _userManager;

        public PatientSecretService(IPatientRepository patientRepository, 
            IUserProfileRepository profileRepository, 
            UserManager<ApplicationUser> userManager)
        {
            _patientRepository = patientRepository;
            _profileRepository = profileRepository;
            _userManager = userManager;
        }

        public async Task<PatientSecretInfo> GetPatientByUserIdAsync(string userId)
        {
            var profile = await _profileRepository.FindByUserIdAsync(userId);
            if (profile is null) 
            {
                throw new NotFoundException("Profile not found!");
            }


            
        }
    }
}
