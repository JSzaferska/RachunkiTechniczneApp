namespace RachunkiTechniczneWebApi.DTOs
{
    public class LoggedUserDto
    {
        public string token { get; set; }
        public int userId { get; set; }
        public string username { get; set; }
        public bool isAdmin { get; set; }
    }
}
