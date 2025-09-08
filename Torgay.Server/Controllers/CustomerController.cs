using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Torgay.Core.DTO;
using Torgay.Core.Services.Payments.Interfaces;
using Torgay.Server.ViewModels.Payments;

namespace Torgay.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CustomerController(ILogger<CurrencyController> logger, IMapper mapper, ICustomerService service)
        : BaseApiController(logger, mapper)
    {
        [HttpGet("Get")]
        //[ValidateAntiForgeryToken]
        //[Authorize(AuthPolicies.ManageAllRolesPolicy)]
        [ProducesResponseType(200, Type = typeof(CustomerVM))]
        public async Task<ActionResult<CustomerVM>> Get(Guid id) {
            var bank = await service.Get(id);
            return Ok(bank);
        }

        [HttpGet("GetList")]
        //[ValidateAntiForgeryToken]
        //[Authorize(AuthPolicies.ManageAllRolesPolicy)]
        [ProducesResponseType(200, Type = typeof(CustomerVM))]
        public async Task<ActionResult<ListResponse>> GetList([FromQuery] ClientListQueryParams queryParams) {
            ListResponse banks = await service.GetList(queryParams);
            return Ok(banks);
        }
    }
}
