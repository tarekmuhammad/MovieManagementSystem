 namespace MovieSystem.Domain.Entities.Commen
{
    public class PackageFeatures : BaseEntity
    {
        public int Id { get; set; }
        public string description { get; set; }
        public ICollection<PackageFeature_details> PackageFeature_details { get; set; }
    }
}
