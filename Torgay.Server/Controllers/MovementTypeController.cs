using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Torgay.Core.Services.Payments.Interfaces;
using Torgay.Server.ViewModels.Payments;

namespace Torgay.Server.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class MovementTypeController(
        ILogger<BaseApiController> logger,
        IMapper mapper,
        IMovementTypeService movementTypeService)
        : BaseApiController(logger, mapper)
    {
        [HttpGet("Get")]
        //[ValidateAntiForgeryToken]
        //[Authorize(AuthPolicies.ManageAllRolesPolicy)]
        [ProducesResponseType(200, Type = typeof(MovementTypeVM))]
        public async Task<ActionResult<BankVM>> Get(Guid id) {
            var bank = await movementTypeService.Get(id);
            return Ok(bank);
        }

        [HttpGet("GetList")]
        //[ValidateAntiForgeryToken]
        //[Authorize(AuthPolicies.ManageAllRolesPolicy)]
        [ProducesResponseType(200, Type = typeof(MovementTypeVM))]
        public async Task<ActionResult<List<BankVM>>> GetList() {
            var banks = await movementTypeService.GetList();
            return Ok(banks);
        }
    }
}
