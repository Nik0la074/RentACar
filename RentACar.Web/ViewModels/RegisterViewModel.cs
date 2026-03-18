using System.ComponentModel.DataAnnotations;

namespace RentACar.Web.ViewModels
{
    /// <summary>
    /// ViewModel for the user registration form.
    /// </summary>
    public class RegisterViewModel
    {
        /// <summary>Unique username for the account.</summary>
        [Required(ErrorMessage = "Username is required")]
        public string UserName { get; set; } = string.Empty;

        /// <summary>First name of the user.</summary>
        [Required(ErrorMessage = "First name is required")]
        public string FirstName { get; set; } = string.Empty;

        /// <summary>Last name of the user.</summary>
        [Required(ErrorMessage = "Last name is required")]
        public string LastName { get; set; } = string.Empty;

        /// <summary>National identification number - must be exactly 10 digits.</summary>
        [Required(ErrorMessage = "EGN is required")]
        [RegularExpression(@"^\d{10}$", ErrorMessage = "EGN must contain exactly 10 digits")]
        public string EGN { get; set; } = string.Empty;

        /// <summary>Phone number of the user.</summary>
        [Required(ErrorMessage = "Phone number is required")]
        [Phone(ErrorMessage = "Invalid phone number")]
        public string PhoneNumber { get; set; } = string.Empty;

        /// <summary>Email address of the user.</summary>
        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid email address")]
        public string Email { get; set; } = string.Empty;

        /// <summary>Password for the account - minimum 6 characters.</summary>
        [Required(ErrorMessage = "Password is required")]
        [MinLength(6, ErrorMessage = "Password must be at least 6 characters")]
        [DataType(DataType.Password)]
        public string Password { get; set; } = string.Empty;

        /// <summary>Must match the Password field.</summary>
        [Required(ErrorMessage = "Password confirmation is required")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Passwords do not match")]
        public string ConfirmPassword { get; set; } = string.Empty;
    }
}