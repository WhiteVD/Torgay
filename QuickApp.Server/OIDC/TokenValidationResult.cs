// ======================================
// Author: Ebenezer Monney
// Copyright (c) 2023 www.ebenmonney.com
// 
// ==> Gun4Hire: contact@ebenmonney.com
// ======================================

using System.Security.Claims;

namespace QuickApp.Server.OIDC
{
    public class TokenValidationResult
    {
        public bool IsValid { get; set; }

        public string? Subject { get; set; }

        public string? Email { get; set; }

        public string? ErrorDescription { get; set; }

        public IEnumerable<Claim>? Claims { get; set; }
    }
}
