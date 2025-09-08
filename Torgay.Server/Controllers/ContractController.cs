using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Torgay.Core.Models.Access;
using Torgay.Core.Models.Payments;
using Torgay.Core.Services.Payments.Interfaces;

namespace Torgay.Server.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ContractController(ILogger<ContractController> logger, IMapper mapper, IContractService service)
        : BaseApiController(logger, mapper)
    {
        [HttpGet("Get")]
        [ProducesResponseType(200, Type = typeof(Contract))]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public async Task<ActionResult<Contract>> Get([FromQuery] Guid id) {
            if (id == Guid.Empty) return BadRequest("Invalid id");
            var contract = await service.Get(id);
            if (contract == null) return NotFound();
            return Ok(contract);
        }

        [HttpGet("GetList")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Contract>))]
        [ProducesResponseType(400)]
        public async Task<ActionResult<IEnumerable<Contract>>> GetList([FromQuery] Guid clientId) {
            if (clientId == Guid.Empty) return BadRequest("Invalid clientId");
            var client = new Client { Id = clientId, Title = string.Empty };
            var list = await service.GetList(client);
            return Ok(list);
        }

        [HttpPost("Create")]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        public ActionResult Create([FromBody] Contract? contract) {
            if (contract == null) return BadRequest("Contract is required");
            if (string.IsNullOrWhiteSpace(contract.Title)) return BadRequest("Title is required");
            if (string.IsNullOrWhiteSpace(contract.Number)) return BadRequest("Number is required");
            if (contract.Client_id == Guid.Empty) return BadRequest("Client_id is required");
            if (contract.Id == Guid.Empty) contract.Id = Guid.NewGuid();
            service.Add(contract);
            return CreatedAtAction(nameof(Get), new { id = contract.Id }, contract);
        }

        [HttpPut("Update")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public ActionResult Update([FromBody] Contract? contract) {
            if (contract == null || contract.Id == Guid.Empty) return BadRequest("Valid Contract with Id is required");
            if (string.IsNullOrWhiteSpace(contract.Title)) return BadRequest("Title is required");
            if (string.IsNullOrWhiteSpace(contract.Number)) return BadRequest("Number is required");
            service.Update(contract);
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
