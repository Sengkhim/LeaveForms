using Application.Conmon.Request.Identity;
using Application.Conmon.Response.Identity;
using Application.Helper;
using Application.Repositery.Service;
using AutoMapper;
using Domain.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Localization;
using Share.Permission;
using Share.Wapper;
using System.Security.Claims;

namespace Application.Implementation.Service
{
    public class RoleService : IRoleService
    {
        private readonly IStringLocalizer<RoleService> _localizer;
        private readonly IMapper _mapper;
        private readonly RoleManager<Role> _roleManager;
        private readonly UserManager<User> _userManager;
        private readonly IHttpContextAccessor httpContextAccessor;



        public RoleService(RoleManager<Role> roleManager, IMapper mapper, UserManager<User> userManager, IStringLocalizer<RoleService> localizer, IHttpContextAccessor httpContextAccessor)
        {
            _roleManager = roleManager;
            _mapper = mapper;
            _userManager = userManager;
            _localizer = localizer;
            this.httpContextAccessor = httpContextAccessor;
        }

        public async Task<IResponse<string>> DeleteAsync(string id)
        {
            var existingRole = await _roleManager.FindByIdAsync(id);
            if (existingRole.Name != RoleConstant.AdministratorRole && existingRole.Name != RoleConstant.BasicRole)
            {
                //TODO Check if Any Users already uses this Role
                var roleIsNotUsed = true;
                var allUsers = await _userManager.Users.ToListAsync();
                foreach (var user in allUsers)
                    if (await _userManager.IsInRoleAsync(user, existingRole.Name))
                        roleIsNotUsed = false;
                if (roleIsNotUsed)
                {
                    await _roleManager.DeleteAsync(existingRole);
                    return await Response<string>.SuccessAsync(
                        $"{_localizer["Role"]} {existingRole.Name} {_localizer["deleted."]}");
                }

                return await Response<string>.FailAsync(
                    $"{_localizer["Not allowed to delete"]} {existingRole.Name} {_localizer["Role as it is being used."]}");
            }

            return await Response<string>.FailAsync(
                $"{_localizer["Not allowed to delete"]} {existingRole.Name} {_localizer["Role"]}.");
        }

        public async Task<IResponse<List<RoleResponse>>> GetAllAsync()
        {
            var roles = await _roleManager.Roles.ToListAsync();
            var rolesResponse = _mapper.Map<List<RoleResponse>>(roles);
            return await Response<List<RoleResponse>>.SuccessAsync(rolesResponse);
        }

        public async Task<IResponse<PermissionResponse>> GetAllPermissionsAsync(string roleId)
        {
            var model = new PermissionResponse();
            var allPermissions = new List<RoleClaimsResponse>();

            #region GetPermissions

            allPermissions.GetPermissions(typeof(Permissions.Users), roleId);
            allPermissions.GetPermissions(typeof(Permissions.Roles), roleId);
            allPermissions.GetPermissions(typeof(Permissions.UserPermission), roleId);


            //You could have your own method to refactor the below line, maybe by using Reflection and fetch directly from a class, else assume that Admin has all the roles assigned and retrieved the Admin's roles here via the DB/Identity.RoleClaims table.
            //allPermissions.Add(new RoleClaimsResponse
            //{ Value = "Permissions.Communication.Chat", Type = ApplicationClaimTypes.Permission });
            #endregion GetPermissions

            var role = await _roleManager.FindByIdAsync(roleId);
            if (role != null)
            {
                model.RoleId = role.Id.ToString();
                model.RoleName = role.Name;
                var claims = await _roleManager.GetClaimsAsync(role);
                var allClaimValues = allPermissions.Select(a => a.Value).ToList();
                var roleClaimValues = claims.Select(a => a.Value).ToList();
                var authorizedClaims = allClaimValues.Intersect(roleClaimValues).ToList();
                foreach (var permission in allPermissions.Where(permission =>
                    authorizedClaims.Any(a => a == permission.Value))) permission.Selected = true;
            }

            model.RoleClaims = allPermissions;
            return await Response<PermissionResponse>.SuccessAsync(model);
        }

        public async Task<IResponse<RoleResponse>> GetByIdAsync(string id)
        {
            var roles = await _roleManager.Roles.SingleOrDefaultAsync(x => x.Id == Guid.Parse(id));
            var rolesResponse = _mapper.Map<RoleResponse>(roles);
            return await Response<RoleResponse>.SuccessAsync(rolesResponse);
        }

        public async Task<IResponse<string>> SaveAsync(RoleRequest request)
        {
                var existingRole = await _roleManager.FindByNameAsync(request.Name);
                if (existingRole != null)
                    return await Response<string>.FailAsync(_localizer["Similar Role already exists."]);
                var response = await _roleManager.CreateAsync(new Role(request.Name, request.Description));
                if (response.Succeeded) return await Response<string>.SuccessAsync(_localizer["Role Created"]);

                return await Response<string>.FailAsync(response.Errors.Select(e => _localizer[e.Description].Value)
                    .ToList());
        }
        public async Task<IResponse<string>> UpdateRoleAsync(RoleRequest request)
        {
            var userId = httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            try
            {
                var find = await _roleManager.FindByIdAsync(request.Id);
                if (find == null) return await Response<string>.FailAsync(_localizer["Object is null."]);

                find.Name = request.Name;
                find.Description = request.Description;
                find.ModifiedByUser = new Guid(userId);
                find.ModifiedDate = DateTimeOffset.Now;
                find.NormalizedName = request.Name.ToUpper();
                find.ConcurrencyStamp = Guid.NewGuid().ToString();

                await _roleManager.UpdateAsync(find);

                return await Response<string>.SuccessAsync(_localizer["Role Update"]);
            }
            catch (Exception ex)
            {
                return await Response<string>.FailAsync(ex.Message);
            }

        }
        public async Task<IResponse<string>> UpdatePermissionsAsync(PermissionRequest request)
        {
            try
            {
                var role = await _roleManager.FindByIdAsync(request.RoleId);
                var claims = await _roleManager.GetClaimsAsync(role);
                foreach (var claim in claims) await _roleManager.RemoveClaimAsync(role, claim);
                var selectedClaims = request.RoleClaims.Where(a => a.Selected).ToList();
                foreach (var claim in selectedClaims)
                {
                    await _roleManager.AddPermissionClaim(role, claim.Value);
                }
                return await Response<string>.SuccessAsync(_localizer["Permission Updated."]);
            }
            catch (Exception ex)
            {
                return await Response<string>.FailAsync(ex.Message);
            }
        }

        public async Task<IResponse<string>> CreatePermissionsAsync(PermissionRequest request)
        {
            try
            {
                var role = await _roleManager.FindByIdAsync(request.RoleId);
                if (role == null) return await Response<string>.FailAsync(
                        _localizer["Not have role id here."]);
                var claims = await _roleManager.GetClaimsAsync(role);
                var selectedClaims = request.RoleClaims.Where(a => a.Selected).ToList();
                foreach (var claim in selectedClaims) 
                {
                    await _roleManager.AddPermissionClaim(role, claim.Value); 
                }
                
                return await Response<string>.SuccessAsync(_localizer["Permission Created."]);
            }
            catch (Exception ex)
            {
                return await Response<string>.FailAsync(ex.Message);
            }
        }
    }
}
