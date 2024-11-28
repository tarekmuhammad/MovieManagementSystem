 namespace MovieSystem.Domain.Entities.Commen
{
    public class Package : BaseEntity
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string? description { get; set; }
        public double? Price { get; set; }
        public ICollection<PackageFeature_details> PackageFeature_details { get; set; }
        public ICollection<Subscriptions> Subscriptions { get; set; }
    }
}
