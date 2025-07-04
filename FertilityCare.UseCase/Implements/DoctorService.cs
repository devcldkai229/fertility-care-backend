﻿using Fertilitycare.Share.Comon;
using Fertilitycare.Share.Pagination;
using FertilityCare.Domain.Entities;
using FertilityCare.UseCase.DTOs.Doctors;
using FertilityCare.UseCase.Interfaces.Repositories;
using FertilityCare.UseCase.Interfaces.Services;
using FertilityCare.UseCase.Mappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace FertilityCare.UseCase.Implements
{
    public class DoctorService : IDoctorService
    {
        private readonly IDoctorRepository _doctorRepository;

        public DoctorService(IDoctorRepository doctorRepository)
        {
            _doctorRepository = doctorRepository;
        }

        public async Task<IEnumerable<DoctorDTO>> GetAllDoctorsAsync()
        {
            var result = await _doctorRepository.FindAllAsync();
            return result.Select(x => x.MapToDoctorDTO()).ToList();
        }

        public async Task<DoctorDTO?> GetDoctorByIdAsync(string id)
        {
            if (!Guid.TryParse(id, out Guid doctorId))
                return null;

            var result = await _doctorRepository.FindByIdAsync(doctorId);
            return result?.MapToDoctorDTO();
        }

        public async Task<IEnumerable<DoctorDTO>> GetDoctorsPagedAsync(PaginationRequestDTO request)
        {
            var result = await _doctorRepository.GetPagedAsync(request.Page, request.PageSize);

            return result.Select(x => x.MapToDoctorDTO()).ToList();

        }
    }
}
