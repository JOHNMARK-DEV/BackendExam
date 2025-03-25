using Microsoft.AspNetCore.Identity;

namespace BackendExam.Models
{
    public class UserModel : IdentityUser
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty; 
    }
}
