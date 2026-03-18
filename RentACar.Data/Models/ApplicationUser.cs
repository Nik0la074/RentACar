using Microsoft.AspNetCore.Identity;

namespace RentACar.Data.Models
{
    /// <summary>
    /// Represents a user in the system, extending the default Identity user.
    /// </summary>
    public class ApplicationUser : IdentityUser
    {
        /// <summary>First name of the user.</summary>
        public string FirstName { get; set; } = string.Empty;

        /// <summary>Last name of the user.</summary>
        public string LastName { get; set; } = string.Empty;

        /// <summary>Unique national identification number (EGN).</summary>
        public string EGN { get; set; } = string.Empty;
    }
}