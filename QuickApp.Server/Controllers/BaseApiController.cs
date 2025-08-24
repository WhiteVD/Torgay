// ======================================
// Author: Ebenezer Monney
// Copyright (c) 2023 www.ebenmonney.com
// 
// ==> Gun4Hire: contact@ebenmonney.com
// ======================================

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
    public class BaseApiController : ControllerBase
    {
        protected readonly IMapper _mapper;
        protected readonly ILogger<BaseApiController> _logger;

        public BaseApiController(ILogger<BaseApiController> logger, IMapper mapper)
        {
            _logger = logger;
            _mapper = mapper;
        }

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
