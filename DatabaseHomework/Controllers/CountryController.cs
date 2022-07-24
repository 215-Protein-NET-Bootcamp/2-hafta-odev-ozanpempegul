using DatabaseHomework.Models;
using DatabaseHomework.Repository;
using Microsoft.AspNetCore.Mvc;

namespace DatabaseHomework.Controllers;

[Route("countries")]
[ApiController]
public class CountryController : ControllerBase
{
    private readonly ICountryRepository _countryRepository;
    

    public CountryController(ICountryRepository countryRepository)
    {
        _countryRepository = countryRepository;
    }

    [HttpGet("GetCountry")]
    public async Task<IActionResult> GetCountry(int id)
    {
        Country country = await _countryRepository.GetCountry(id);
        if (country == null) return NotFound();
        return Ok(country);
    }

    [HttpGet("GetCountries")]
    public async Task<IActionResult> GetAllCountries()
    {
        IEnumerable<Country> countries = await _countryRepository.GetAllCountries();
        return Ok(countries);
    }

    [HttpPost("AddNewCountry")]
    public async Task<IActionResult> AddNewCountry(Country country)
    {
        _countryRepository.AddCountry(country);
        _countryRepository.SaveCountry(country);
        return Ok(country);
    }


}
