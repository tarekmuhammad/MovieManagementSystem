namespace MovieSystem.Domain.Entities.Commen
{
    public class Permissions : BaseEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
       // public ICollection<Roles> Roles { get; set; }
       // public ICollection<Users> Users { get; set; }
    }
}
