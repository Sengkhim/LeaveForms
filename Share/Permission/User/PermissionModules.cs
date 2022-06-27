

namespace Share.Permission.User
{
    public static class PermissionModules
    {
        public const string Users = "Users";
        public const string Roles = "Roles";
        public const string UserPermissions = "UserPermissions";
        public static List<string> GeneratePermissionsForModule(string module)
        {
            return new()
            {
                $"Permissions.{module}.Create",
                $"Permissions.{module}.View",
                $"Permissions.{module}.Edit",
                $"Permissions.{module}.Delete"
            };
        }
    }
    public static class PermissionModulesUser
    {
        public const string Users = "Users";
        public static List<string> GeneratePermissionsForModule(string module)
        {
            return new()
            {
                $"Permissions.{module}.Create",
                $"Permissions.{module}.View",
                $"Permissions.{module}.Edit",
            };
        }
    }
}
