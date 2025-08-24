using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Torgay.Core.Services.Payments.Interfaces;
using Torgay.Server.ViewModels.Payments;

namespace Torgay.Server.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class MovementTypeController : BaseApiController {
        private readonly IMovementTypeService _movementTypeService;

        public MovementTypeController(ILogger<BaseApiController> logger, IMapper mapper, IMovementTypeService movementTypeService) : base(logger, mapper) {
            _movementTypeService = movementTypeService;
        }

        [HttpGet("Get")]
        //[ValidateAntiForgeryToken]
        //[Authorize(AuthPolicies.ManageAllRolesPolicy)]
        [ProducesResponseType(200, Type = typeof(MovementTypeVM))]
        public async Task<ActionResult<BankVM>> Get(Guid id) {
            var bank = await _movementTypeService.Get(id);
            return Ok(bank);
        }

        [HttpGet("GetList")]
        //[ValidateAntiForgeryToken]
        //[Authorize(AuthPolicies.ManageAllRolesPolicy)]
        [ProducesResponseType(200, Type = typeof(MovementTypeVM))]
        public async Task<ActionResult<List<BankVM>>> GetList() {
            var banks = await _movementTypeService.GetList();
            return Ok(banks);
        }
    }
}
