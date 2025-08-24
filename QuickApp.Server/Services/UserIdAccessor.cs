// ======================================
// Author: Ebenezer Monney
// Copyright (c) 2023 www.ebenmonney.com
// 
// ==> Gun4Hire: contact@ebenmonney.com
// ======================================

using Torgay.Core.Services.Account;
using System.Security.Claims;
using static OpenIddict.Abstractions.OpenIddictConstants;

namespace Torgay.Server.Services
{
    public class UserIdAccessor(IHttpContextAccessor httpContextAccessor) : IUserIdAccessor
    {
        private readonly IHttpContextAccessor _httpContextAccessor = httpContextAccessor;

        public string? GetCurrentUserId() => _httpContextAccessor.HttpContext?.User.FindFirstValue(Claims.Subject);
    }

    public class SystemUserIdAccessor : IUserIdAccessor
    {
        private readonly string? id;

        private SystemUserIdAccessor(string? id) => this.id = id;

        public string? GetCurrentUserId() => id;

        public static SystemUserIdAccessor GetNewAccessor(string? id = "SYSTEM") => new(id);
    }
}
