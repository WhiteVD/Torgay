﻿// ======================================
// Author: Ebenezer Monney
// Copyright (c) 2023 www.ebenmonney.com
// 
// ==> Gun4Hire: contact@ebenmonney.com
// ======================================

using Microsoft.Extensions.Options;
using Torgay.Server.Configuration;

namespace Torgay.Server.OIDC.TokenValidators
{
    public class MicrosoftTokenValidator : TokenValidator
    {
        private readonly OidcAuthConfig _providerConfig;

        public MicrosoftTokenValidator(IOptions<AppSettings> options, ILogger<MicrosoftTokenValidator> logger)
            : base(logger)
        {
            _providerConfig = options.Value.ExternalLogin?.Microsoft ??
                throw new InvalidOperationException("Configuration for \"Microsoft\" External Login was not found.");
        }

        public override async Task<TokenValidationResult> ValidateTokenAsync(string token)
        {
            return await ValidateOpenIdConnectTokenAsync(
                token,
                _providerConfig.ClientId,
                _providerConfig.Issuer,
                _providerConfig.ValidateIssuer);
        }
    }
}
