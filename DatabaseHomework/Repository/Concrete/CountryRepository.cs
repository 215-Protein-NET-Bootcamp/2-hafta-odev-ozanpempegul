using DatabaseHomework.DbProvider;
using DatabaseHomework.Models;

namespace DatabaseHomework.Repository;

public class CountryRepository : ICountryRepository
{
    private readonly IDapperDbProvider _dapperDbProvider;

    private const string InsertCountrySqlStatement = @"INSERT INTO country (CountryName, Continent, Currency) VALUES(@CountryName, @Continent, @Currency)";
    private const string SelectCountrySqlStatement = @"SELECT * FROM country WHERE CountryId = @Id LIMIT 1";
    private const string SelectAllCountrySqlStatement = @"SELECT * FROM country LIMIT 50";
    private const string DeleteCountrySqlStatement = @"DELETE country WHERE CountryId = @Id LIMIT 1";

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

        return await _dapperDbProvider.QueryAsync<Country>(connection, SelectAllCountrySqlStatement);
    }
    public async Task<Country> DeleteCountry(int id)
    {
        using var connection = _dapperDbProvider.GetConnection();

        return await _dapperDbProvider.QueryFirstOrDefaultAsync<Country>(connection, DeleteCountrySqlStatement, new { Id = id });
    }
}