namespace MovieSystem.Domain.Entities.Commen
{
    public class Category:BaseEntity
    {
        public int Id {get; set;}
        public string Name {get; set;}
        public int? ParentId {get; set;}
        public Category Parent {get; set;}
        public virtual ICollection<Category> subcategories { get; set; }
        public virtual ICollection<Movie> Movies { get; set; }

    }
}
