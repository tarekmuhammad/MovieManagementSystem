

namespace MovieSystem.Domain.Entities.Commen
{
   //[Table("Users", Schema = "HR")]
 
    public class Users 
    {
        //[Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Id { get; set; }
        //public string Name { get; set; }
        //public string Email { get; set; }
        //public string Password { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public bool Type { get; set; }
        public bool isPaid { get; set; }

        //public ICollection<RoleUser> RoleUser {get; set;}
        public ICollection<Permissions> Permissions {get; set;}
        public ICollection<Reviews> Reviews {get; set;}
        public ICollection<Like> Likes {get; set;}
        public ICollection<Subscriptions> Subscriptions {get; set;}
        //public ICollection<UserMovie> History {get; set;}
    }
}
