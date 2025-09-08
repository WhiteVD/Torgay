using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Torgay.Core.Models.Payments;
using Torgay.Core.Services.Payments.Interfaces;

namespace Torgay.Server.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class AccountTypeController(ILogger<BaseApiController> logger, IMapper mapper, IAccountTypeService service)
        : BaseApiController(logger, mapper)
    {
        [HttpGet("Get")]
        [ProducesResponseType(200, Type = typeof(AccountType))]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public async Task<ActionResult<AccountType>> Get([FromQuery] Guid id) {
            if (id == Guid.Empty) return BadRequest("Invalid id");
            var item = await service.Get(id);
            if (item == null) return NotFound();
            return Ok(item);
        }

        [HttpGet("GetList")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<AccountType>))]
        public async Task<ActionResult<IEnumerable<AccountType>>> GetList() {
            var list = await service.GetList();
            return Ok(list);
        }

        [HttpPost("Create")]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        public ActionResult Create([FromBody] AccountType? accountType) {
            if (accountType == null) return BadRequest("AccountType is required");
            if (string.IsNullOrWhiteSpace(accountType.Title)) return BadRequest("Title is required");
            if (accountType.Id == Guid.Empty) accountType.Id = Guid.NewGuid();
            service.Add(accountType);
            return CreatedAtAction(nameof(Get), new { id = accountType.Id }, accountType);
        }

        [HttpPut("Update")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public ActionResult Update([FromBody] AccountType accountType) {
            if (accountType.Id == Guid.Empty) return BadRequest("Valid AccountType with Id is required");
            if (string.IsNullOrWhiteSpace(accountType.Title)) return BadRequest("Title is required");
            service.Update(accountType);
            return NoContent();
        }

        [HttpDelete("Delete")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public ActionResult Delete([FromQuery] Guid id) {
            if (id == Guid.Empty) return BadRequest("Invalid id");
            service.Delete(id);
            return NoContent();
        }
    }
}
