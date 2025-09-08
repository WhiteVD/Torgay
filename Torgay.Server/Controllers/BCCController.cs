using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Torgay.Core.Services.Payments.Interfaces;
using Torgay.Server.ViewModels.Payments;

namespace Torgay.Server.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class BCCController(ILogger<BaseApiController> logger, IMapper mapper, IBCCService service)
        : BaseApiController(logger, mapper)
    {
        [HttpGet("Get")]
        [ProducesResponseType(200, Type = typeof(Torgay.Core.Models.Payments.BCC))]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public async Task<ActionResult<Torgay.Core.Models.Payments.BCC>> Get([FromQuery] Guid id) {
            if (id == Guid.Empty) return BadRequest("Invalid id");
            var item = await service.Get(id);
            if (item == null) return NotFound();
            return Ok(item);
        }

        [HttpGet("GetList")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Torgay.Core.Models.Payments.BCC>))]
        public async Task<ActionResult<IEnumerable<Torgay.Core.Models.Payments.BCC>>> GetList() {
            var list = await service.GetList();
            return Ok(list);
        }

        [HttpPost("Create")]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        public ActionResult Create([FromBody] Torgay.Core.Models.Payments.BCC bcc) {
            if (bcc == null) return BadRequest("BCC is required");
            if (string.IsNullOrWhiteSpace(bcc.Code)) return BadRequest("Code is required");
            if (string.IsNullOrWhiteSpace(bcc.Title)) return BadRequest("Title is required");
            if (bcc.Id == Guid.Empty) bcc.Id = Guid.NewGuid();
            service.Add(bcc);
            return CreatedAtAction(nameof(Get), new { id = bcc.Id }, bcc);
        }

        [HttpPut("Update")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public ActionResult Update([FromBody] Torgay.Core.Models.Payments.BCC bcc) {
            if (bcc == null || bcc.Id == Guid.Empty) return BadRequest("Valid BCC with Id is required");
            if (string.IsNullOrWhiteSpace(bcc.Code)) return BadRequest("Code is required");
            if (string.IsNullOrWhiteSpace(bcc.Title)) return BadRequest("Title is required");
            service.Update(bcc);
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
