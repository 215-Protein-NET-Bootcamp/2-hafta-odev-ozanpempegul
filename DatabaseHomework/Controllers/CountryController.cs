using DatabaseHomework.DbProvider;
using DatabaseHomework.Models;
using DatabaseHomework.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DatabaseHomework.Controllers;

[Route("countries")]
[ApiController]
public class CountryController : ControllerBase
{
    private readonly CountryRepository _countryRepository;
    private readonly PatikaDbContext _patikaDbContext;

    public CountryController(CountryRepository countryRepository, PatikaDbContext patikaDbContext)
    {
        _countryRepository = countryRepository;
        _patikaDbContext = patikaDbContext;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        Country country = new Country
        {
            CountryName = "Tr",
            Continent = "Eu",
            Currency = "TRY"
        };
        
        await _countryRepository.SaveCountry(country);
        return Ok();
    }

    //[HttpGet("department/{id}")]
    //public async Task<IActionResult> GetDepartment(int id)
    //{
    //    Department department = await _countryRepository.GetDepartment(id);
    //    // Employee employee = new Employee
    //    // {
    //    //     DeptId = 1,
    //    //     EmpName = "Ozan",
    //    //     EmpID = 1
    //    // };
    //    //
    //    // _patikaDbContext.Employee.Add(employee);
    //    // await _patikaDbContext.SaveChangesAsync();
    //    return Ok(department);
    //}

    [HttpGet("country/all")]
    public async Task<IActionResult> GetAllCountries()
    {
        IEnumerable<Country> countries = await _countryRepository.GetAllCountries();
        return Ok(countries);
    }


    [HttpDelete("country/delete")]
    public async Task<IActionResult> DeleteCountry(int id)
    {
        Country country = await _countryRepository.DeleteCountry(id);

        await _patikaDbContext.SaveChangesAsync();
        return Ok(country);
    }
}