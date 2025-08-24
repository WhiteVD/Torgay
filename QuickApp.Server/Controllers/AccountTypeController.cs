using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Torgay.Core.Services.Payments.Interfaces;
using Torgay.Server.ViewModels.Payments;

namespace Torgay.Server.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class AccountTypeController : BaseApiController {
        private readonly IAccountTypeService _accountTypeService;

        public AccountTypeController(ILogger<BaseApiController> logger, IMapper mapper, IAccountTypeService accountTypeService) : base(logger, mapper) {
            _accountTypeService = accountTypeService;
        }

        [HttpGet("Get")]
        //[ValidateAntiForgeryToken]
        //[Authorize(AuthPolicies.ManageAllRolesPolicy)]
        [ProducesResponseType(200, Type = typeof(AccountTypeVM))]
        public async Task<ActionResult<BankVM>> Get(Guid id) {
            var bank = await _accountTypeService.Get(id);
            return Ok(bank);
        }

        [HttpGet("GetList")]
        //[ValidateAntiForgeryToken]
        //[Authorize(AuthPolicies.ManageAllRolesPolicy)]
        [ProducesResponseType(200, Type = typeof(AccountTypeVM))]
        public async Task<ActionResult<List<BankVM>>> GetList() {
            var banks = await _accountTypeService.GetList();
            return Ok(banks);
        }
    }
}
