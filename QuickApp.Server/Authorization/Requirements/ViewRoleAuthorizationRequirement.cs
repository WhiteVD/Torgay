// ======================================
// Author: Ebenezer Monney
// Copyright (c) 2023 www.ebenmonney.com
// 
// ==> Gun4Hire: contact@ebenmonney.com
// ======================================

using Microsoft.AspNetCore.Authorization;
using Torgay.Core.Services.Account;

namespace Torgay.Server.Authorization.Requirements
{
    public class ViewRoleAuthorizationRequirement : IAuthorizationRequirement
    {

    }

    public class ViewRoleAuthorizationHandler : AuthorizationHandler<ViewRoleAuthorizationRequirement, string>
    {
        protected override Task HandleRequirementAsync(
            AuthorizationHandlerContext context, ViewRoleAuthorizationRequirement requirement, string roleName)
        {
            if (context.User == null)
                return Task.CompletedTask;

            if (context.User.HasClaim(CustomClaims.Permission, ApplicationPermissions.ViewRoles)
                || context.User.IsInRole(roleName))
                context.Succeed(requirement);

            return Task.CompletedTask;
        }
    }
}
