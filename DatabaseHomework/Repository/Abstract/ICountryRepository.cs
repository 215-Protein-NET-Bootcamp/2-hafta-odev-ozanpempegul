using DatabaseHomework.Models;

namespace DatabaseHomework.Repository
{
    public interface ICountryRepository
    {
        Task<Country> GetCountry(int id);
        Task SaveCountry(Country country);
        Task<IEnumerable<Country>> GetAllCountries();
        Task<Country> DeleteCountry(int id);
    }
}
