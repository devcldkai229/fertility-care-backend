﻿using FertilityCare.Infrastructure.Identity;
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

        private readonly IOrderRepository _orderRepository;

        private readonly IUserProfileRepository _profileRepository;

        public PatientSecretService(IPatientRepository patientRepository, 
            IUserProfileRepository profileRepository, 
            UserManager<ApplicationUser> userManager,
            IOrderRepository orderRepository)
        {
            _patientRepository = patientRepository;
            _profileRepository = profileRepository;
            _orderRepository = orderRepository;
        }

        public async Task<PatientSecretInfo> GetPatientByUserIdAsync(string userId)
        {
            var profile = await _profileRepository.FindByUserIdAsync(userId);
            if (profile is null) 
            {
                throw new NotFoundException("Profile not found!");
            }

            var patient = await _patientRepository.FindByProfileIdAsync(profile.Id);
            if (patient is null)
            {
                throw new NotFoundException("Patient not found");
            }
            
            var orders = await _orderRepository.FindAllByPatientIdAsync(patient.Id);
            return new PatientSecretInfo
            {
                PatientId = patient.Id.ToString(),
                UserProfileId = profile.Id.ToString(),
                OrderIds = orders.Select(o => o.Id.ToString()).ToList(),
            };
        }
    }
}
