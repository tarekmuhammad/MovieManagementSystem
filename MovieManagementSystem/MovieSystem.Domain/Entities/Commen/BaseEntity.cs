namespace MovieSystem.Domain.Entities.Commen
{
    public  class BaseEntity
    {
        //public bool? IsActive { get; set; }
        public DateTime? EntryDate { get; set; }
        public string? EnteredBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string? UpdatedBy { get; set; }
        public string? HostName { get; set; }
        public string? IPaddress { get; set; }
    }
}
