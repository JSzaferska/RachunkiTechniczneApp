namespace RachunkiTechniczneWebApi.DTOs.Admin
{
    public class UserDto
    {
        public int UserId { get; set; }
        public string Owner { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public bool IsAdmin { get; set; }
    }
}
