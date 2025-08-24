using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Torgay.Core.DTO;
using Torgay.Core.Services.Payments.Interfaces;
using Torgay.Server.DTO;
using Torgay.Server.ViewModels.Payments;

namespace Torgay.Server.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class BankController : BaseApiController {
        private readonly IBankService _service;

        public BankController(ILogger<BankController> logger, IMapper mapper, IBankService Service) : base(logger, mapper) {
            _service = Service;
        }

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //[Authorize(AuthPolicies.ManageAllRolesPolicy)]
        //[ProducesResponseType(201, Type = typeof(RoleVM))]
        //[ProducesResponseType(400)]
        //public Task<ActionResult> Create(IFormCollection collection) {
        //    try {
        //        return RedirectToAction(nameof(Index));
        //    } catch {
        //        return View();
        //    }
        //}

        [HttpGet("Get")]
        //[ValidateAntiForgeryToken]
        //[Authorize(AuthPolicies.ManageAllRolesPolicy)]
        [ProducesResponseType(200, Type = typeof(BankVM))]
        public async Task<ActionResult<BankVM>> Get(Guid id) {
            var ret = await _service.Get(id);
            return Ok(ret);
        }

        [HttpGet("GetList")]
        //[ValidateAntiForgeryToken]
        //[Authorize(AuthPolicies.ManageAllRolesPolicy)]
        [ProducesResponseType(200, Type = typeof(BankVM))]
        public async Task<ActionResult<ListResponse>> GetList([FromQuery] ListQueryParams queryParams) {
            ListResponse ret = await _service.GetList(queryParams);
            return Ok(ret);
        }
    }
}
