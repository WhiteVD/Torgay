// ======================================
// Author: Ebenezer Monney
// Copyright (c) 2023 www.ebenmonney.com
// 
// ==> Gun4Hire: contact@ebenmonney.com
// ======================================

using QuickApp.Server.OIDC.TokenValidators;

namespace QuickApp.Server.OIDC
{
    public class TokenValidatorOptions
    {
        private readonly Dictionary<string, Type> validatorMap = new(StringComparer.OrdinalIgnoreCase);

        public void AddValidator<T>(string provider) where T : TokenValidator
        {
            ArgumentNullException.ThrowIfNull(provider);

            validatorMap[provider] = typeof(T);
        }

        public Type? GetValidator(string provider)
        {
            ArgumentNullException.ThrowIfNull(provider);

            return validatorMap.TryGetValue(provider, out var value) ? value : null;
        }
    }
}
