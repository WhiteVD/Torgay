using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Torgay.Core.DTO;
using Torgay.Core.Services.Payments.Interfaces;
using Torgay.Server.DTO;
using Torgay.Server.ViewModels.Payments;

namespace Torgay.Server.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CurrencyController(ILogger<CurrencyController> logger, IMapper mapper, ICurrencyService service)
        : BaseApiController(logger, mapper)
    {
        [HttpGet("Get")]
        //[ValidateAntiForgeryToken]
        //[Authorize(AuthPolicies.ManageAllRolesPolicy)]
        [ProducesResponseType(200, Type = typeof(CurrencyVM))]
        public async Task<ActionResult<CurrencyVM>> Get(Guid id) {
            var ret = await service.Get(id);
            return Ok(ret);
        }

        [HttpGet("GetList")]
        //[ValidateAntiForgeryToken]
        //[Authorize(AuthPolicies.ManageAllRolesPolicy)]
        [ProducesResponseType(200, Type = typeof(CurrencyVM))]
        public async Task<ActionResult<ListResponse>> GetList([FromQuery] ListQueryParams queryParams) {
            ListResponse ret = await service.GetList(queryParams);
            return Ok(ret);
        }
    }
}
