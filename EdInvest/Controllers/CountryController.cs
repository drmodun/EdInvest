using API.Routes;
using Domain.Services;
using Microsoft.AspNetCore.Mvc;
using Shared.Models;

namespace API.Controllers
{
    [ApiController]
    public class CountryController : ControllerBase
    {
        private readonly CountryService _countryService;

        public CountryController(CountryService countryService)
        {
            _countryService = countryService;
        }
        [HttpGet(AppRoutes.Country.Get)]
        public async Task<ActionResult<Country?>> Get([FromRoute] Guid id)
        {
            return await _countryService.GetById(id);
        }
        [HttpGet(AppRoutes.Country.GetAll)]
        public async Task<ActionResult<List<Country>>> GetAll()
        {
            return await _countryService.GetAll();
        }

    }
}
