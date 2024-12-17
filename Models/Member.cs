
namespace NonProfitBlazorSite.Models
{
    public class Member
    {
        public int MemberId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public string Role { get; set; } // New field for role-based access
        public DateTime CreatedDate { get; set; }
    }
}
