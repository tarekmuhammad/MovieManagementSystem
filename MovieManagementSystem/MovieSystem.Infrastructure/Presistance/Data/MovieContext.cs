using Microsoft.EntityFrameworkCore;
using MovieSystem.Infrastructure.Presistance.Seeding;
using MovieSystem.Domain.Entities.Commen;
using MovieSystem.Infrastructure.Presistance.Data.FluentApi;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using MovieSystem.Infrastructure.Presistance.Models;



namespace MovieSystem.Infrastructure.Presistance.Data
{
    public class MovieContext : IdentityDbContext<ApplicationUser, ApplicationRole, string>
    {
        public MovieContext(DbContextOptions<MovieContext> opts) : base(opts) 
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
           // new DbInitializer(modelBuilder).Seed();
            new UserConfiguration().Configure(modelBuilder.Entity<ApplicationUser>());
            new RoleConfiguration().Configure(modelBuilder.Entity<ApplicationRole>());
           // new RoleUserConfiguration().Configure(modelBuilder.Entity<RoleUser>());
            new PermissionsConfiguration().Configure(modelBuilder.Entity<Permissions>());
            new CategoryConfiguration().Configure(modelBuilder.Entity<Category>());
            new CountryConfiguration().Configure(modelBuilder.Entity<Country>());
            new MovieConfiguration().Configure(modelBuilder.Entity<Movie>());
            new UserMovieConfiguration().Configure(modelBuilder.Entity<Presistance.Models.UserMovie>());
            new CastConfiguration().Configure(modelBuilder.Entity<Cast>());
            new MovieCastConfiguration().Configure(modelBuilder.Entity<MovieCast>());
            
            
           
            new ReviewsConfiguration().Configure(modelBuilder.Entity<Reviews>());
            new LikeConfiguration().Configure(modelBuilder.Entity<Like>());
            new PackageConfiguration().Configure(modelBuilder.Entity<Package>());
            new PackageFeaturesConfiguration().Configure(modelBuilder.Entity<PackageFeatures>());
            new PackageFeature_detailsConfiguration().Configure(modelBuilder.Entity<PackageFeature_details>());
            new SubscriptionsConfiguration().Configure(modelBuilder.Entity<Subscriptions>());

 
            //modelBuilder.Entity<Permissions>().ToTable("Permissions", "Identity"); 
            modelBuilder.Entity<IdentityUserRole<string>>().ToTable("UserRole", "Identity"); 
            modelBuilder.Entity<IdentityUserClaim<string>>().ToTable("UserPermission", "Identity"); 
            modelBuilder.Entity<IdentityRoleClaim<string>>().ToTable("RolePermission", "Identity");
            modelBuilder.Entity<IdentityUserLogin<string>>().ToTable("UserLogin", "Identity");
            modelBuilder.Entity<IdentityUserToken<string>>().ToTable("UserToken", "Identity");


        }

        //public DbSet<Users> Users { get; set; }
        //public DbSet<Roles> Roles { get; set; }
        //public DbSet<RoleUser> RoleUser { get; set; }
        public DbSet<Permissions> Permissions { get; set; }
       //public DbSet<RolePermissions> RolePermissions { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Category> Categories { get; set; }
        //New
        public DbSet<Models.UserMovie> UserMovie { get; set; }
        public DbSet<Country> Country { get; set; }
        public DbSet<Cast> Cast { get; set; }
        public DbSet<MovieCast> Moviecast { get; set; }
        public DbSet<Package> Package { get; set; }
        public DbSet<PackageFeatures> PackageFeatures { get; set; }
        public DbSet<PackageFeature_details> PackageFeature_details { get; set; }
        public DbSet<Subscriptions> Subscriptions { get; set; }
    }
}
