// ======================================
// Author: Ebenezer Monney
// Copyright (c) 2023 www.ebenmonney.com
// 
// ==> Gun4Hire: contact@ebenmonney.com
// ======================================

namespace Torgay.Core.Infrastructure
{
    public interface IDatabaseSeeder
    {
        Task SeedAsync(string? defaultUserRole);
    }
}
