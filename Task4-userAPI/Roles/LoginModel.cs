using System.ComponentModel.DataAnnotations;

namespace Task4_userAPI.Roles
{
    public class LoginModel
    {

        [Required(ErrorMessage = "User Name is required")]
        public string? Username { get; set; }

        [Required(ErrorMessage = "Password is required")]
        public string? Password { get; set; }
         int GetUserIdFromCredentials(LoginModel loginModel)
        {
            throw new NotImplementedException();
        }
    }
}
