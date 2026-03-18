using System.ComponentModel.DataAnnotations;

namespace RentACar.Web.ViewModels
{
    /// <summary>
    /// ViewModel for the user login form.
    /// </summary>
    public class LoginViewModel
    {
        /// <summary>Username of the account.</summary>
        [Required(ErrorMessage = "Username is required")]
        public string UserName { get; set; } = string.Empty;

        /// <summary>Password of the account.</summary>
        [Required(ErrorMessage = "Password is required")]
        [DataType(DataType.Password)]
        public string Password { get; set; } = string.Empty;

        /// <summary>Whether to persist the login session.</summary>
        public bool RememberMe { get; set; }
    }
}