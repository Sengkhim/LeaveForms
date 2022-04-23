using Application.Conmon.Request.Identity;
using Application.Conmon.Response.Identity;
using Domain.Authentication;
using Microsoft.AspNetCore.Identity;
using Share.Permission;
using Share.Permission.User;
using System.Reflection;
using System.Security.Claims;

namespace Application.Helper
{
    public static class ClaimHelper
    {
        /// <summary>
        ///  get user permission only value field
        /// </summary>
        /// <param name="items"></param>
        /// <param name="user"></param>
        /// <param name="UserId"></param>
        /// <returns></returns>
        public static void GetAllUserPermission(this List<UserClaimRequests> items,
        Type policy, string UserId)
        {
            var fields = policy.GetFields(BindingFlags.Static | BindingFlags.Public);
            items.AddRange(fields.Select(e => new UserClaimRequests
            {
                Type = "Permission",
                Value = e.GetValue(e)!.ToString()
            }).ToList()) ;
        }

        /// <summary>
        /// get permission
        /// </summary>
        /// <param name="allPermissions"></param>
        /// <param name="policy"></param>
        /// <param name="roleId"></param>
        public static void GetPermissions(this List<RoleClaimsResponse> allPermissions, Type policy, string roleId)
        {
            var fields = policy.GetFields(BindingFlags.Static | BindingFlags.Public);
            allPermissions.AddRange(fields.Select(fi => new RoleClaimsResponse
            { Value = fi.GetValue(null)!.ToString(), Type = ApplicationClaimTypes.Permission }));
        }

        /// <summary>
        ///  Add claim role
        /// </summary>
        /// <param name="roleManager"></param>
        /// <param name="role"></param>
        /// <param name="permission"></param>
        /// <returns></returns>
        public static async Task AddPermissionClaim(this RoleManager<Role> roleManager, Role role, string permission)
        {
            var allClaims = await roleManager.GetClaimsAsync(role);
            if (!allClaims.Any(a => a.Type == ApplicationClaimTypes.Permission && a.Value == permission))
                await roleManager.AddClaimAsync(role, new Claim(ApplicationClaimTypes.Permission, permission));
        }

        /// <summary>
        ///   Create user claim
        /// </summary>
        /// <param name="user"></param>
        /// <param name="userClaim"></param>
        /// <param name="permission"></param>
        /// <returns></returns>
        public static async Task AddUserClaimPermission(this UserManager<User> user, User userClaim, string permission)
        {
            var UserClaim = await user.GetClaimsAsync(userClaim);
            if (!UserClaim.Any(a => a.Type == ApplicationClaimTypes.Permission && a.Value == permission))
                await user.AddClaimAsync(userClaim, new Claim(ApplicationClaimTypes.Permission, permission));
        }



        /// <summary>
        /// 
        /// </summary>
        /// <param name="roleManager"></param>
        /// <param name="role"></param>
        /// <param name="module"></param>
        /// <returns></returns>
        public static async Task GeneratePermissionClaimByModule(this RoleManager<Role> roleManager, Role role, string module)
        {
            var allClaims = await roleManager.GetClaimsAsync(role);
            var allPermissions = PermissionModules.GeneratePermissionsForModule(module);
            foreach (var permission in allPermissions.Where(permission =>
                !allClaims.Any(a => a.Type == ApplicationClaimTypes.Permission && a.Value == permission)))
                await roleManager.AddClaimAsync(role, new Claim(ApplicationClaimTypes.Permission, permission));
        }
    }
}
