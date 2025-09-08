// ======================================
// Author: Ebenezer Monney
// Copyright (c) 2023 www.ebenmonney.com
// 
// ==> Gun4Hire: contact@ebenmonney.com
// ======================================

using Torgay.Core.Models.Account;

namespace Torgay.Server.OIDC
{
    public class UserResolutionResult
    {
        public UserResolutionResult(ApplicationUser user)
        {
            User = user;
        }

        public UserResolutionResult(string errorMessage, Dictionary<string, string>? errorData = null)
        {
            ErrorMessage = errorMessage;
            ErrorData = errorData;
        }

        public bool IsError => !string.IsNullOrWhiteSpace(ErrorMessage) || ErrorData?.Count > 0;

        public ApplicationUser? User { get; set; }

        public string? ErrorMessage { get; set; }

        public Dictionary<string, string>? ErrorData { get; set; }
    }
}
