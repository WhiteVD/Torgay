using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Torgay.Core.Services.Payments.Interfaces;
using Torgay.Server.ViewModels.Payments;

namespace Torgay.Server.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class BCCController : BaseApiController {
        private readonly IBCCService _BCCService;

        public BCCController(ILogger<BaseApiController> logger, IMapper mapper, IBCCService bCCService) : base(logger, mapper) {
            _BCCService = bCCService;
        }

        [HttpGet("Get")]
        //[ValidateAntiForgeryToken]
        //[Authorize(AuthPolicies.ManageAllRolesPolicy)]
        [ProducesResponseType(200, Type = typeof(BCCVM))]
        public async Task<ActionResult<BankVM>> Get(Guid id) {
            var bank = await _BCCService.Get(id);
            return Ok(bank);
        }

        [HttpGet("GetList")]
        //[ValidateAntiForgeryToken]
        //[Authorize(AuthPolicies.ManageAllRolesPolicy)]
        [ProducesResponseType(200, Type = typeof(BCCVM))]
        public async Task<ActionResult<List<BankVM>>> GetList() {
            var banks = await _BCCService.GetList();
            return Ok(banks);
        }
    }
}
