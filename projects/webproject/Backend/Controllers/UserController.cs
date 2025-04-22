
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("[controller]")]
public class UserController : ControllerBase
{
    [HttpPost("login")]
    public IActionResult Login([FromBody] User user)
    {
        // Hardcoded authentication
        if (user.Username == "user" && user.Password == "pass")
        {
            return Ok(new { message = "Login successful" });
        }
        return Unauthorized();
    }
}

public class User
{
    public string Username { get; set; }
    public string Password { get; set; }
}
