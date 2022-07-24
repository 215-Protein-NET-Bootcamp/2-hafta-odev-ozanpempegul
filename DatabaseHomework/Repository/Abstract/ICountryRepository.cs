using DatabaseHomework.Models;

namespace DatabaseHomework.Repository
{
    public interface ICountryRepository
    {
        Task<Country> GetCountry(int id);
        Task<IEnumerable<Country>> GetAllCountries();
        Task<IEnumerable<Country>> AddCountry(Country country);
        Task<Country> UpdateCountry(Country country);
        Task<Country> DeleteCountry(int id);
        public Task SaveCountry(Country country);
    }
}
