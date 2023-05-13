﻿using Domain.Repositories.Interfaces;
using Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services
{
    public class CountryService
    {
        //I do not see a need to implement special dtos for countries at this time
        private readonly ICountryRepo _countryRepo;

        public CountryService(ICountryRepo countryRepo)
        {
            _countryRepo = countryRepo;
        }

        public async Task<Country?> GetById(Guid id)
        {
            return await _countryRepo.GetById(id);
        }
        public async Task<List<Country>> GetAll()
        {
            return await _countryRepo.GetAll();
        }
    }
}
