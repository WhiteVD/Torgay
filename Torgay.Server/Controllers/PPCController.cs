using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Torgay.Core.Services.Payments.Interfaces;
using Torgay.Server.ViewModels.Payments;

namespace Torgay.Server.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class PPCController(ILogger<BaseApiController> logger, IMapper mapper, IPPCService pPcService)
        : BaseApiController(logger, mapper)
    {
        [HttpGet("Get")]
        //[ValidateAntiForgeryToken]
        //[Authorize(AuthPolicies.ManageAllRolesPolicy)]
        [ProducesResponseType(200, Type = typeof(PPCVM))]
        public async Task<ActionResult<BankVM>> Get(Guid id) {
            var bank = await pPcService.Get(id);
            return Ok(bank);
        }

        [HttpGet("GetList")]
        //[ValidateAntiForgeryToken]
        //[Authorize(AuthPolicies.ManageAllRolesPolicy)]
        [ProducesResponseType(200, Type = typeof(PPCVM))]
        public async Task<ActionResult<List<BankVM>>> GetList() {
            var banks = await pPcService.GetList();
            return Ok(banks);
        }
    }
}
