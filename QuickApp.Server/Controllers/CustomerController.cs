using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using QuickApp.Core.DTO;
using QuickApp.Core.Services.Payments.Interfaces;
using QuickApp.Server.ViewModels.Payments;

namespace QuickApp.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CustomerController : BaseApiController {
        private readonly ICustomerService _service;

        public CustomerController(ILogger<CurrencyController> logger, IMapper mapper, ICustomerService Service) : base(logger, mapper) {
            _service = Service;
        }

        [HttpGet("Get")]
        //[ValidateAntiForgeryToken]
        //[Authorize(AuthPolicies.ManageAllRolesPolicy)]
        [ProducesResponseType(200, Type = typeof(CustomerVM))]
        public async Task<ActionResult<CustomerVM>> Get(Guid id) {
            var bank = await _service.Get(id);
            return Ok(bank);
        }

        [HttpGet("GetList")]
        //[ValidateAntiForgeryToken]
        //[Authorize(AuthPolicies.ManageAllRolesPolicy)]
        [ProducesResponseType(200, Type = typeof(CustomerVM))]
        public async Task<ActionResult<ListResponse>> GetList([FromQuery] ClientListQueryParams queryParams) {
            ListResponse banks = await _service.GetList(queryParams);
            return Ok(banks);
        }
    }
}
