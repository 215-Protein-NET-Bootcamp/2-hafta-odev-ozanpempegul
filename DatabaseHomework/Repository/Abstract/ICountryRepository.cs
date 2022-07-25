﻿using DatabaseHomework.Models;

namespace DatabaseHomework.Repository
{
    public interface ICountryRepository
    {
        Task<Country> GetCountry(int id);
        Task<IEnumerable<Country>> GetAllCountries();
        Task<Country> AddCountry(Country country);
        Task<Country> UpdateCountry(Country country);
        Task DeleteCountry(int id);
        Task SaveCountry(Country country);
    }
}
