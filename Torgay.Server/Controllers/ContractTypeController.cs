using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Torgay.Core.Services.Payments.Interfaces;
using Torgay.Server.ViewModels.Payments;

namespace Torgay.Server.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ContractTypeController(
        ILogger<BaseApiController> logger,
        IMapper mapper,
        IContractTypeService contractTypeService)
        : BaseApiController(logger, mapper)
    {
        [HttpGet("Get")]
        //[ValidateAntiForgeryToken]
        //[Authorize(AuthPolicies.ManageAllRolesPolicy)]
        [ProducesResponseType(200, Type = typeof(ContractTypeVM))]
        public async Task<ActionResult<BankVM>> Get(Guid id) {
            var bank = await contractTypeService.Get(id);
            return Ok(bank);
        }

        [HttpGet("GetList")]
        //[ValidateAntiForgeryToken]
        //[Authorize(AuthPolicies.ManageAllRolesPolicy)]
        [ProducesResponseType(200, Type = typeof(ContractTypeVM))]
        public async Task<ActionResult<List<BankVM>>> GetList() {
            var banks = await contractTypeService.GetList();
            return Ok(banks);
        }
    }
}
