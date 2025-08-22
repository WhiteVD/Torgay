// ======================================
// Author: Ebenezer Monney
// Copyright (c) 2023 www.ebenmonney.com
// 
// ==> Gun4Hire: contact@ebenmonney.com
// ======================================

namespace QuickApp.Core.Services.Account
{
    public interface IUserIdAccessor
    {
        string? GetCurrentUserId();
    }
}
