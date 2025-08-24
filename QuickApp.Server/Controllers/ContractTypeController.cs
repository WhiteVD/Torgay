using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Torgay.Core.Services.Payments.Interfaces;
using Torgay.Server.ViewModels.Payments;

namespace Torgay.Server.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ContractTypeController : BaseApiController {
        private readonly IContractTypeService _contractTypeService;

        public ContractTypeController(ILogger<BaseApiController> logger, IMapper mapper, IContractTypeService contractTypeService) : base(logger, mapper) {
            _contractTypeService = contractTypeService;
        }

        [HttpGet("Get")]
        //[ValidateAntiForgeryToken]
        //[Authorize(AuthPolicies.ManageAllRolesPolicy)]
        [ProducesResponseType(200, Type = typeof(ContractTypeVM))]
        public async Task<ActionResult<BankVM>> Get(Guid id) {
            var bank = await _contractTypeService.Get(id);
            return Ok(bank);
        }

        [HttpGet("GetList")]
        //[ValidateAntiForgeryToken]
        //[Authorize(AuthPolicies.ManageAllRolesPolicy)]
        [ProducesResponseType(200, Type = typeof(ContractTypeVM))]
        public async Task<ActionResult<List<BankVM>>> GetList() {
            var banks = await _contractTypeService.GetList();
            return Ok(banks);
        }
    }
}
