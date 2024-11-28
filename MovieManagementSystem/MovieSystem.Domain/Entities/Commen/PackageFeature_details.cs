namespace MovieSystem.Domain.Entities.Commen
{
    public class PackageFeature_details : BaseEntity
    {
        public int PackageId { get; set; }
        public Package package { get; set; }
        public int PackageFeatureId { get; set; }
        public PackageFeatures PackageFeatures { get; set; }
    }
}
