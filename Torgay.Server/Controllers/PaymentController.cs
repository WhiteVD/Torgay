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
    public class PaymentController : BaseApiController {
        private readonly IPaymentService _service;

        public PaymentController(ILogger<PaymentController> logger, IMapper mapper, IPaymentService service) : base(logger, mapper) {
            _service = service;
        }

        [HttpGet("Get")]
        [ProducesResponseType(200, Type = typeof(Payment))]
        [ProducesResponseType(404)]
        public async Task<ActionResult<Payment>> Get([FromQuery] Guid id) {
            if (id == Guid.Empty) return BadRequest("Invalid id");
            var payment = await _service.Get(id);
            if (payment == null) return NotFound();
            return Ok(payment);
        }

        [HttpGet("GetList")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Payment>))]
        public async Task<ActionResult<IEnumerable<Payment>>> GetList([FromQuery] Guid clientId) {
            if (clientId == Guid.Empty) return BadRequest("Invalid clientId");
            // PaymentService only needs Client.Id for filtering
            var client = new Client { Id = clientId, Title = string.Empty };
            var list = await _service.GetList(client);
            return Ok(list);
        }

        [HttpPost("Create")]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        public ActionResult Create([FromBody] Payment payment) {
            if (payment == null) return BadRequest("Payment is required");
            if (string.IsNullOrWhiteSpace(payment.PaymentId)) return BadRequest("PaymentId is required");

            // Set defaults if needed
            if (payment.Id == Guid.Empty) payment.Id = Guid.NewGuid();
            if (payment.ActualDate == default) payment.ActualDate = DateTime.UtcNow;

            _service.Add(payment);
            return CreatedAtAction(nameof(Get), new { id = payment.Id }, payment);
        }

        [HttpPut("Update")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public ActionResult Update([FromBody] Payment payment) {
            if (payment == null || payment.Id == Guid.Empty) return BadRequest("Valid Payment with Id is required");
            _service.Update(payment);
            return NoContent();
        }

        [HttpDelete("Delete")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public ActionResult Delete([FromQuery] Guid id) {
            if (id == Guid.Empty) return BadRequest("Invalid id");
            _service.Delete(id);
            return NoContent();
        }
    }
}