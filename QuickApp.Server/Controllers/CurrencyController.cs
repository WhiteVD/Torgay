using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using QuickApp.Core.DTO;
using QuickApp.Core.Services.Payments.Interfaces;
using QuickApp.Server.DTO;
using QuickApp.Server.ViewModels.Payments;

namespace QuickApp.Server.Controllers {
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
