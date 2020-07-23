using Services.Enums;

namespace JansenVerhuurAPI.Responses
{
    public class UserResponse
    {
        public int Id { get; set; }
        public string Firstname { get; set; }
        public string Middlename { get; set; }
        public string Lastname { get; set; }
        public string Email { get; set; }
        public Role Role { get; set; }
    }
}
