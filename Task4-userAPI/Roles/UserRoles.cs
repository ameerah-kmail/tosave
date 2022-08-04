using Microsoft.AspNetCore.Identity;

namespace Task4_userAPI.Roles
{
    public class UserRoles:IdentityRole<int>
    {
        public static string Admin = "Admin";
        public static string User = "User";
    }
}
