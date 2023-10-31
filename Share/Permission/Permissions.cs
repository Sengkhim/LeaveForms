
namespace Share.Permission
{
    public static class Permissions
    {
        public static class Users
        {
            public const string View = "Permissions.Users.View";
            public const string SecretView = "Permissions.Users.SecretView";
            public const string Create = "Permissions.Users.Create";
            public const string Edit = "Permissions.Users.Edit";
            public const string Delete = "Permissions.Users.Delete";
            public const string CreateClaimRole = "Permissions.Users.CreateClaimRole";
            public const string CreatePermissionRole = "Permissions.Users.CreatePermissionRole";
            public const string CreateUserPermission = "Permissions.Users.CreateUserPermission";
        }

        public static class Roles
        {
            public const string View = "Permissions.Roles.View";
            public const string Create = "Permissions.Roles.Create";
            public const string Edit = "Permissions.Roles.Edit";
            public const string Delete = "Permissions.Roles.Delete";
        }

        public static class UserPermission 
        {
            public const string View = "Permissions.UserPermission.View";
            public const string Create = "Permissions.UserPermission.Create";
            public const string Delete = "Permissions.UserPermission.Delete";
            public const string Edit = "Permissions.UserPermission.Edit";
        }
    }
}
