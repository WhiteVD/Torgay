﻿using Microsoft.Extensions.Options;
using Torgay.Server.Configuration;

namespace Torgay.Server.OIDC.TokenValidators
{
    public class FacebookTokenValidator : TokenValidator
    {
        private readonly OidcAuthConfig _providerConfig;

        public FacebookTokenValidator(IOptions<AppSettings> options, ILogger<FacebookTokenValidator> logger)
            : base(logger)
        {
            _providerConfig = options.Value.ExternalLogin?.Facebook ??
                throw new InvalidOperationException("Configuration for \"Facebook\" External Login was not found.");
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
