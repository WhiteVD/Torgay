using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Torgay.Core.DTO;
using Torgay.Core.Models.Payments;
using Torgay.Core.Services.Payments.Interfaces;
using Torgay.Server.DTO;

namespace Torgay.Server.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class BankController(ILogger<BankController> logger, IMapper mapper, IBankService service)
        : BaseApiController(logger, mapper)
    {
        [HttpGet("Get")]
        //[ValidateAntiForgeryToken]
        //[Authorize(AuthPolicies.ManageAllRolesPolicy)]
        [ProducesResponseType(200, Type = typeof(Bank))]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public async Task<ActionResult<Bank>> Get([FromQuery] Guid id) {
            if (id == Guid.Empty) return BadRequest("Invalid id");
            var ret = await service.Get(id);
            if (ret == null) return NotFound();
            return Ok(ret);
        }

        [HttpGet("GetList")]
        //[ValidateAntiForgeryToken]
        //[Authorize(AuthPolicies.ManageAllRolesPolicy)]
        [ProducesResponseType(200, Type = typeof(ListResponse))]
        public async Task<ActionResult<ListResponse>> GetList([FromQuery] ListQueryParams queryParams) {
            ListResponse ret = await service.GetList(queryParams);
            return Ok(ret);
        }

        [HttpPost("Create")]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        public ActionResult Create([FromBody] Bank? bank) {
            if (bank == null) return BadRequest("Bank is required");
            if (string.IsNullOrWhiteSpace(bank.Title)) return BadRequest("Title is required");
            if (string.IsNullOrWhiteSpace(bank.BIC)) return BadRequest("BIC is required");
            if (bank.Id == Guid.Empty) bank.Id = Guid.NewGuid();
            service.Add(bank);
            return CreatedAtAction(nameof(Get), new { id = bank.Id }, bank);
        }

        [HttpPut("Update")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public ActionResult Update([FromBody] Bank? bank) {
            if (bank == null || bank.Id == Guid.Empty) return BadRequest("Valid Bank with Id is required");
            if (string.IsNullOrWhiteSpace(bank.Title)) return BadRequest("Title is required");
            if (string.IsNullOrWhiteSpace(bank.BIC)) return BadRequest("BIC is required");
            service.Update(bank);
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
