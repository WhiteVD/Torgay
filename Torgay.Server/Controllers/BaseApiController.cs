using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Torgay.Core.Services.Account;
using Torgay.Server.Attributes;
using Torgay.Server.Services;

namespace Torgay.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [SanitizeModel]
    public class BaseApiController(ILogger<BaseApiController> logger, IMapper mapper) : ControllerBase
    {
        protected readonly IMapper _mapper = mapper;
        protected readonly ILogger<BaseApiController> _logger = logger;

        protected string GetCurrentUserId(string errorMsg = "Error retrieving the userId for the current user.")
        {
            return Utilities.GetUserId(User) ?? throw new UserNotFoundException(errorMsg);
        }

        protected void AddModelError(IEnumerable<string> errors, string key = "")
        {
            foreach (var error in errors)
            {
                AddModelError(error, key);
            }
        }

        protected void AddModelError(string error, string key = "")
        {
            ModelState.AddModelError(key, error);
        }
    }
}
