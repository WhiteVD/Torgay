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
    public class CurrencyController : BaseApiController {
        private readonly ICurrencyService _service;

        public CurrencyController(ILogger<CurrencyController> logger, IMapper mapper, ICurrencyService Service) : base(logger, mapper) {
            _service = Service;
        }

        [HttpGet("Get")]
        //[ValidateAntiForgeryToken]
        //[Authorize(AuthPolicies.ManageAllRolesPolicy)]
        [ProducesResponseType(200, Type = typeof(CurrencyVM))]
        public async Task<ActionResult<CurrencyVM>> Get(Guid id) {
            var ret = await _service.Get(id);
            return Ok(ret);
        }

        [HttpGet("GetList")]
        //[ValidateAntiForgeryToken]
        //[Authorize(AuthPolicies.ManageAllRolesPolicy)]
        [ProducesResponseType(200, Type = typeof(CurrencyVM))]
        public async Task<ActionResult<ListResponse>> GetList([FromQuery] ListQueryParams queryParams) {
            ListResponse ret = await _service.GetList(queryParams);
            return Ok(ret);
        }
    }
}
