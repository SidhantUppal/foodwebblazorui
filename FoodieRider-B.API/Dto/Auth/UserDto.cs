using System.ComponentModel.DataAnnotations;

namespace FoodieRider.API.Dto.Auth
{
    public class UserDto
    {
        [Required]
        [DataType(DataType.EmailAddress)]
        public required string Email { get; set; }
        [Required]
        [DataType(DataType.Password)]

        public required string Password { get; set; }
        [Required]
        [StringLength(50, ErrorMessage = "Name is too long.")]
        public required string FirstName { get; set; }
        [Required]
        [MinLength(3, ErrorMessage = "Name is too short.")]
        [MaxLength(40, ErrorMessage = "Name is too long.")]
        public required string LastName { get; set; }
    }

    public class LoginDto
    {
        public required string Email { get; set; }
        public required string Password { get; set; }
        public string? TwoFactorCode { get; set; }
        public string? TwoFactorRecoveryCode { get; set; }
    }
    public class UserSearch : UserDto
    {
        public string UserName { get; init; }
        public string PhoneNumber { get; init; }
        public List<string> Roles { get; init; }
    }
}
