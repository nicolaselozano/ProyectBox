using Users.Models;

public class ResponseUserDTO
{
    public User user{ get; set; }
    public string token { get; set; }
    public string refreshToken { get; set; }
}