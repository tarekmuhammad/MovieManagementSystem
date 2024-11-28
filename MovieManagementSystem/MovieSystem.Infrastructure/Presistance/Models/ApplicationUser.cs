using Microsoft.AspNetCore.Identity;
using MovieSystem.Domain.Entities.Commen;

namespace MovieSystem.Infrastructure.Presistance.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public bool Type { get; set; }
        public bool isPaid { get; set; }
       // public ICollection<RoleUser> RoleUser { get; set; }
        //public ICollection<Permissions> Permissions { get; set; }
        public ICollection<Reviews> Reviews { get; set; }
        public ICollection<Like> Likes { get; set; }
        public ICollection<Subscriptions> Subscriptions { get; set; }
        public ICollection<UserMovie> History { get; set; }
    }
}
