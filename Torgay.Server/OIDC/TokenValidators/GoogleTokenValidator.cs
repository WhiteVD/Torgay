﻿using Microsoft.Extensions.Options;
using Torgay.Server.Configuration;

namespace Torgay.Server.OIDC.TokenValidators
{
    public class GoogleTokenValidator : TokenValidator
    {
        private readonly OidcAuthConfig _providerConfig;

        public GoogleTokenValidator(IOptions<AppSettings> options, ILogger<GoogleTokenValidator> logger)
            : base(logger)
        {
            _providerConfig = options.Value.ExternalLogin?.Google ??
                throw new InvalidOperationException("Configuration for \"Google\" External Login was not found.");
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
