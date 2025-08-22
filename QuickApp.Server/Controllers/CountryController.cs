using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using QuickApp.Core.Services.Payments.Interfaces;
using QuickApp.Server.ViewModels.Payments;

namespace QuickApp.Server.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CountryController : BaseApiController {
        private readonly ICountryService _countryService;

        public CountryController(ILogger<BaseApiController> logger, IMapper mapper, ICountryService countryService) : base(logger, mapper) {
            _countryService = countryService;
        }

        [HttpGet("Get")]
        //[ValidateAntiForgeryToken]
        //[Authorize(AuthPolicies.ManageAllRolesPolicy)]
        [ProducesResponseType(200, Type = typeof(CountryVM))]
        public async Task<ActionResult<BankVM>> Get(Guid id) {
            var bank = await _countryService.Get(id);
            return Ok(bank);
        }

        [HttpGet("GetList")]
        //[ValidateAntiForgeryToken]
        //[Authorize(AuthPolicies.ManageAllRolesPolicy)]
        [ProducesResponseType(200, Type = typeof(CountryVM))]
        public async Task<ActionResult<List<BankVM>>> GetList() {
            var banks = await _countryService.GetList();
            return Ok(banks);
        }
    }
}
