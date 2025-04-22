using Microsoft.AspNetCore.Identity;

namespace mihoyo_events.Models
{
    public class UserProfile : IdentityUser
    {
        public DateTime JoinDate { get; set; } = DateTime.UtcNow;
        public string AvatarUrl { get; set; }
    }
}