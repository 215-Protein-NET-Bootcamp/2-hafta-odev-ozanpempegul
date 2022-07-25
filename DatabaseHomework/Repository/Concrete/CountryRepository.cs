using DatabaseHomework.DbProvider;
using DatabaseHomework.Models;

namespace DatabaseHomework.Repository;

public class CountryRepository : ICountryRepository
{
    private readonly IDapperDbProvider _dapperDbProvider;

    private const string InsertCountrySqlStatement = @"INSERT INTO country (CountryName, Continent, Currency) VALUES(@CountryName, @Continent, @Currency)";
    private const string SelectCountrySqlStatement = @"SELECT * FROM country WHERE CountryId = @Id LIMIT 1";
    private const string SelectAllCountriesSqlStatement = @"SELECT * FROM country LIMIT 50";
    private const string UpdateCountrySqlStatement = @"UPDATE country SET countryname = @country.countryname, continent = @country.continent, currency = @country.currency WHERE CountryId = @Id";
    private const string DeleteCountrySqlStatement = @"DELETE FROM public.country WHERE countryid = @id;";

    public CountryRepository(IDapperDbProvider dapperDbProvider)
    {
        _dapperDbProvider = dapperDbProvider;
    }

    public async Task SaveCountry(Country country)
    {
        using var connection = _dapperDbProvider.GetConnection();

        await _dapperDbProvider.ExecuteAsync(connection, InsertCountrySqlStatement, country);
    }

    public async Task<Country> GetCountry(int id)
    {
        using var connection = _dapperDbProvider.GetConnection();

        return await _dapperDbProvider.QueryFirstOrDefaultAsync<Country>(connection, SelectCountrySqlStatement, new { Id = id });
    }

    public async Task<IEnumerable<Country>> GetAllCountries()
    {
        using var connection = _dapperDbProvider.GetConnection();

        return await _dapperDbProvider.QueryAsync<Country>(connection, SelectAllCountriesSqlStatement);
    }

    public async Task<Country> AddCountry(Country country)
    {
        using var connection = _dapperDbProvider.GetConnection();

        return await _dapperDbProvider.QueryFirstOrDefaultAsync<Country>(connection, InsertCountrySqlStatement);
    }

    public async Task<Country> UpdateCountry(Country country)
    {
        using var connection = _dapperDbProvider.GetConnection();

        return await _dapperDbProvider.QueryFirstOrDefaultAsync<Country>(connection, UpdateCountrySqlStatement, country);        
    }

    public async Task DeleteCountry(int id)
    {
        using var connection = _dapperDbProvider.GetConnection();

        await _dapperDbProvider.ExecuteAsync(connection, DeleteCountrySqlStatement, new { Id = id });
    }
}