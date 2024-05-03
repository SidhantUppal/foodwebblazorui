
using Microsoft.AspNetCore.Identity;

namespace FoodieRider.DAL.Model.Auth
{
    public class User : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
