using System.ComponentModel.DataAnnotations;

namespace ReviewAppProject.Models
{
    public class UserUpdateModel
    {
        public int UserId { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }

        public int? Course { get; set; }
        public int? FacultyId { get; set; }
    }
}
