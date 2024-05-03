namespace FoodieRider.API.Dto.Auth
{
    public class UserDto
    {
        public required string Email { get; init; }
        public required string Password { get; init; }
        public required string FirstName { get; init; }
        public required string LastName { get; init; }
    }
    public class UserSearch : UserDto
    {
        public string UserName { get; init; }
        public string PhoneNumber { get; init; }
        public List<string> Roles { get; init; }
    }
}
