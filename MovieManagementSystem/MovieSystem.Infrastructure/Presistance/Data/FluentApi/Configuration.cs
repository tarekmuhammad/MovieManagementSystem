using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using MovieSystem.Domain.Entities.Commen;
using MovieSystem.Infrastructure.Presistance.Data.FluentApi;
using MovieSystem.Infrastructure.Presistance.Seeding;
using System.Reflection.Emit;
using MovieSystem.Domain.Helper;
using MovieSystem.Infrastructure.Presistance.Models;



namespace MovieSystem.Infrastructure.Presistance.Data.FluentApi
{
    internal class Configuration
    {
    }

     
     
    public class UserConfiguration : IEntityTypeConfiguration<ApplicationUser>
    {
        public void Configure(EntityTypeBuilder<ApplicationUser> builder)
        {
            
            builder.ToTable("Users", schema: "Identity");
            builder.HasKey(x => x.Id);

            //builder.Property(t => t.Id)
            //        .HasColumnType("int")
            //        .HasColumnName("UserId");

            //builder.Property(t => t.UserName)
            //        .HasColumnName("UserName")
            //        .HasColumnType("Nvarchar(50)")
            //        .IsRequired();

            //builder.Property(t => t.Email)
            //        .HasColumnName("Email")W
            //        .HasColumnType("Nvarchar(50)")
            //        .IsRequired();

            //builder.Property(t => t.PasswordHash)
            //        .HasColumnName("PWD")
            //        .HasColumnType("Nvarchar(50)")
            //        .IsRequired();

            builder.Property(t => t.Age)
                    .HasColumnName("Age")
                    .HasColumnType("smallint"); 
            
            builder.Property(t => t.Type)
                    .HasColumnName("UserType")
                    .HasColumnType("tinyint");

            //builder.HasMany(m => m.RoleUser)
            //        .WithOne(r => r.User)
            //        .HasForeignKey(p => p.UserId)
            //        .OnDelete(DeleteBehavior.Cascade);

            //builder.HasMany(t => t.Reviews)
            //       .WithOne(r => r.User)
            //       .HasForeignKey(p => p.UserId)
            //       .OnDelete(DeleteBehavior.NoAction);

            //builder.HasMany(t => t.Likes)
            //       .WithOne(r => r.User)
            //       .HasForeignKey(p => p.UserId)
            //       .OnDelete(DeleteBehavior.NoAction);

            //builder.HasMany(t => t.History)
            //       .WithOne(r => r.User)
            //       .HasForeignKey(p => p.UserId)
            //       .OnDelete(DeleteBehavior.Cascade);

            //builder.HasMany(t => t.Subscriptions)
            //       .WithOne(r => r.User)
            //       .HasForeignKey(p => p.UserId)
            //       .OnDelete(DeleteBehavior.Cascade);

        }
    }

    public class RoleConfiguration : IEntityTypeConfiguration<ApplicationRole>
    {
        public void Configure(EntityTypeBuilder<ApplicationRole> builder)
        {
            builder.ToTable("Roles", schema: "Identity");
            builder.HasKey(x => x.Id);


            //builder.Property(t => t.Id)
            //        .HasColumnType("int")
            //        .HasColumnName("RoleId");

            //builder.Property(t => t.Name)
            //        .HasColumnName("UserName")
            //        .HasColumnType("Nvarchar(50)")
            //        .IsRequired();
                    

            //builder.HasMany(m => m.RoleUser)
            //        .WithOne(r => r.Role)
            //        .HasForeignKey(p => p.RoleId)
            //        .OnDelete(DeleteBehavior.NoAction);

        }
    }

    //public class RoleUserConfiguration : IEntityTypeConfiguration<RoleUser>
    //{
    //    public void Configure(EntityTypeBuilder<RoleUser> builder)
    //    {
    //        //builder.ToTable("RoleUser", schema: "Identity");
    //        //builder.HasKey(x => new { x.UserId, x.RoleId });

    //        //builder.Property(t => t.UserId)
    //        //        .HasColumnName("UserId")
    //        //        .HasColumnType("int");
    //        //builder.Property(t => t.RoleId)
    //        //        .HasColumnName("RoleId")
    //        //        .HasColumnType("int"); 
    //        //builder.Property(t => t.isActive)
    //        //        .HasColumnName("isActive")
    //        //        .HasColumnType("tinyint");
    //    }
    //}

    public class PermissionsConfiguration : IEntityTypeConfiguration<Permissions>
    {
        public void Configure(EntityTypeBuilder<Permissions> builder)
        {
            builder.ToTable("Permissions", schema: "Identity");
            builder.HasKey(x => x.Id); 
            
            builder.Property(t => t.Id)
                    .HasColumnType("int")
                    .HasColumnName("PermissionId");

            builder.Property(t => t.Name)
                    .HasColumnName("PermissionName")
                    .HasColumnType("Nvarchar(50)")
                    .IsRequired();
            

            //builder.HasMany(m => m.Roles)
            //         .WithMany(r => r.Permissions)
            //         .UsingEntity(j =>
            //         {
            //             j.ToTable("RolePermissions", "Identity");
            //             j.Property("RolesId").HasColumnName("RoleId").HasColumnType("int");
            //             j.Property("PermissionsId").HasColumnName("PermissionId").HasColumnType("int");
            //             j.HasKey("RolesId", "PermissionsId");
            //         });

            //builder.HasMany(m => m.Roles)
            //         .WithMany(r => r.Permissions)
            //         .UsingEntity(
            //                l => l
            //                .HasOne(typeof(ApplicationRole))
            //                .WithMany()
            //                .HasForeignKey("RolesId")
            //                .HasPrincipalKey(nameof(ApplicationRole.Id))
            //                .OnDelete(DeleteBehavior.Cascade),

            //                r => r
            //                .HasOne(typeof(Permissions))
            //                .WithMany()
            //                .HasForeignKey("PermissionsId")
            //                .HasPrincipalKey(nameof(Permissions.Id))
            //                .OnDelete(DeleteBehavior.NoAction)
            //                );



            //builder.HasMany(m => m.Users)
            //     .WithMany(r => r.Permissions)
            //     .UsingEntity(j =>
            //     {
            //         j.ToTable("UserPermissions", "Identity");
            //         j.Property("UsersId").HasColumnName("UserId").HasColumnType("int");
            //         j.Property("PermissionsId").HasColumnName("PermissionId").HasColumnType("int");
            //         j.HasKey("UsersId", "PermissionsId");
            //     });


            //    builder.HasMany(m => m.Users)
            //         .WithMany(r => r.Permissions)
            //         .UsingEntity(
            //                l => l
            //                .HasOne(typeof(ApplicationUser))
            //                .WithMany()
            //                .HasForeignKey("UsersId")
            //                .HasPrincipalKey(nameof(ApplicationUser.Id))
            //                .OnDelete(DeleteBehavior.Cascade),

            //            r => r
            //            .HasOne(typeof(Permissions))
            //            .WithMany()
            //            .HasForeignKey("PermissionsId")
            //            .HasPrincipalKey(nameof(Permissions.Id))
            //            .OnDelete(DeleteBehavior.NoAction)
            //            );





            //builder.HasMany(m => m.Roles)
            //        .WithMany(r => r.Permissions)
            //        .UsingEntity(j => {
            //            j.ToTable("RolePermissions", "Identity");
            //            j.Property("RolesId").HasColumnName("RoleId").HasColumnType("int");
            //            j.Property("PermissionsId").HasColumnName("PermissionId").HasColumnType("int");
            //            j.HasOne(typeof(Roles), "Permissions")
            //                .WithMany()
            //               .HasForeignKey("RolesId")
            //               .HasPrincipalKey(nameof(Roles.Id))
            //               .OnDelete(DeleteBehavior.Cascade);



            //j.HasOne(typeof(Permission))
            //    .WithMany()
            //    .HasForeignKey("PermissionsId")
            //    .HasPrincipalKey(nameof(Permission.Id))
            //    .OnDelete(DeleteBehavior.NoAction);
            //});


        }
    }

    public class MovieConfiguration : IEntityTypeConfiguration<Movie>
    {
        public void Configure(EntityTypeBuilder<Movie> builder)
        {
            builder.ToTable("Movies", schema: "App");
            builder.HasKey(x => x.Id);

            builder.Property(t => t.Id)
                     .HasColumnType("int");
                     //.HasColumnName("MovieId");

            builder.Property(t => t.Name)
                    .HasColumnName("MovieName")
                    .HasColumnType("Nvarchar(50)")
                    .IsRequired();

            builder.Property(t => t.Description)
                    .HasColumnName("Description")
                    .HasColumnType("Nvarchar(1000)");

            builder.Property(t => t.Image)
                    .HasColumnName("Image")
                    .HasColumnType("Nvarchar(250)")
                    .IsRequired();

            builder.Property(t => t.Video)
                    .HasColumnName("Video")
                    .HasColumnType("Nvarchar(250)")
                    .IsRequired(); 
            builder.Property(t => t.IsFree)
                    .HasColumnName("IsFree")
                    .HasColumnType("tinyint");

             
            builder.HasMany(m => m.Reviews)
                    .WithOne(r => r.Movie)
                    .HasForeignKey(p => p.MovieId)
                    .OnDelete(DeleteBehavior.NoAction);

            //

            //builder.HasMany(m => m.History)
            //        .WithOne(r => r.Movie)
            //        .HasForeignKey(p => p.MovieId)
            //        .OnDelete(DeleteBehavior.NoAction);

            builder.HasMany(m => m.MovieCast)
                    .WithOne(r => r.Movie)
                    .HasForeignKey(p => p.MovieId)
                    .OnDelete(DeleteBehavior.Cascade);

        }
    }

    public class UserMovieConfiguration : IEntityTypeConfiguration<Models.UserMovie>
    {
        public void Configure(EntityTypeBuilder<Models.UserMovie> builder)
        {
            builder.ToTable("UserMovie", schema: "App");
            builder.HasKey(x => new { x.UserId, x.MovieId });

            builder.Property(t => t.UserId)
                    .HasColumnName("UserId");

            builder.Property(t => t.MovieId)
                    .HasColumnName("MovieId")
                    .HasColumnType("int");
            builder.Property(t => t.watchDate)
                  .HasColumnName("WatchDate")
                  .HasColumnType("datetime");
            builder.Property(t => t.lastSeen)
                  .HasColumnName("LastSeen")
                  .HasColumnType("datetime");
        }
    }

    public class MovieCastConfiguration : IEntityTypeConfiguration<MovieCast>
    {
        public void Configure(EntityTypeBuilder<MovieCast> builder)
        {
            builder.ToTable("MovieCast", schema: "App");
            builder.HasKey(x => new { x.MovieId, x.CastId });

            builder.Property(t => t.MovieId)
                   .HasColumnType("int")
                   .HasColumnName("MovieId");

            builder.Property(t => t.CastId)
                    .HasColumnName("CastId")
                    .HasColumnType("int");
        }
    }



    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.ToTable("Categories", schema: "App");
            builder.HasKey(x => x.Id);

            builder.Property(t => t.Id)
                    .HasColumnType("int")
                    .HasColumnName("CategoryId");


            builder.Property(t => t.Name)
                    .HasColumnName("CategoryName")
                    .HasColumnType("Nvarchar(50)")
                    .IsRequired();

            builder.Property(t => t.ParentId)
                    .HasColumnName("ParentId")
                    .HasColumnType("int");

            builder.HasMany(m => m.subcategories)
                    .WithOne(r => r.Parent)
                    .HasForeignKey(p => p.ParentId)
                    .OnDelete(DeleteBehavior.NoAction);

            builder.HasMany(b=> b.Movies)
                    .WithOne(b => b.category)
                    .HasForeignKey(p => p.CategoryId)
                    .OnDelete(DeleteBehavior.NoAction);
        }
    }

    public class CountryConfiguration : IEntityTypeConfiguration<Country>
    {
        public void Configure(EntityTypeBuilder<Country> builder)
        {
            builder.ToTable("Country", schema: "App");
            builder.HasKey(x => x.Id);

            builder.Property(t => t.Id)
                    .HasColumnType("int")
                    .HasColumnName("CountryId");


            builder.Property(t => t.Name)
                    .HasColumnName("CountryName")
                    .HasColumnType("Nvarchar(200)")
                    .IsRequired();
 
            builder.HasMany(b => b.Movies)
                    .WithOne(b => b.Country)
                    .HasForeignKey(p => p.CountryId)
                    .OnDelete(DeleteBehavior.NoAction);

            builder.HasMany(b => b.Cast)
                    .WithOne(b => b.Country)
                    .HasForeignKey(p => p.CountryId)
                    .OnDelete(DeleteBehavior.NoAction);
        }
    }

    public class CastConfiguration : IEntityTypeConfiguration<Cast>
    {
        public void Configure(EntityTypeBuilder<Cast> builder)
        {
            builder.ToTable("Cast", schema: "App");
            builder.HasKey(x => x.Id);

            builder.Property(t => t.Id)
                    .HasColumnType("int")
                    .HasColumnName("CastId");
            builder.Property(t => t.Name)
                    .HasColumnType("Nvarchar(200)")
                    .HasColumnName("Name")
                    .IsRequired();
            builder.Property(t => t.Type)
                    .HasColumnType("int")
                    .HasColumnName("CastType")
                    .IsRequired();
            builder.Property(t => t.CountryId)
                    .HasColumnName("CountryId")
                    .HasColumnType("int");
            builder.HasMany(b => b.MovieCast)
                    .WithOne(b => b.Cast)
                    .HasForeignKey(p => p.CastId)
                    .OnDelete(DeleteBehavior.NoAction);
        }
    }

    public class ReviewsConfiguration : IEntityTypeConfiguration<Reviews>
    {
        public void Configure(EntityTypeBuilder<Reviews> builder)
        {
            builder.ToTable("Reviews", schema: "App");
            builder.HasKey(x => x.Id);

            builder.Property(t => t.Id)
                    .HasColumnType("int")
                    .HasColumnName("ReviewId");


            builder.Property(t => t.Content)
                    .HasColumnName("Content")
                    .HasColumnType("Nvarchar(250)")
                    .IsRequired();

            builder.Property(t => t.Rate)
                    .HasColumnName("Rate")
                    .HasColumnType("smallint")
                    .IsRequired();

            builder.Property(t => t.Date)
                   .HasColumnName("Date")
                   .HasColumnType("datetime")
                   .IsRequired();

            builder.Property(t => t.UserId)
                   .HasColumnName("UserId")
                   .HasColumnType("int")
                   .IsRequired(); 

            builder.Property(t => t.MovieId)
                   .HasColumnName("MovieId")
                   .HasColumnType("int")
                   .IsRequired();
  
            builder.HasMany(m => m.Likes)
                    .WithOne(r => r.Review)
                    .HasForeignKey(p => p.Reviewid)
                    .OnDelete(DeleteBehavior.Cascade);
        }
    }

    public class LikeConfiguration : IEntityTypeConfiguration<Like>
    {
        public void Configure(EntityTypeBuilder<Like> builder)
        {
            builder.ToTable("Likes", schema: "App");
            builder.HasKey(x => x.Id);

            builder.Property(t => t.Id)
                   .HasColumnType("int")
                   .HasColumnName("LikeId");

            //builder.Property(t => t.UserId)
            //        .HasColumnName("Userid")
            //        .HasColumnType("int")
            //        .IsRequired();

            builder.Property(t => t.Reviewid)
                    .HasColumnName("Reviewid")
                    .HasColumnType("int")
                    .IsRequired();

            builder.Property(t => t.isLiked)
                   .HasColumnName("isLiked")
                   .HasColumnType("tinyint")
                   .IsRequired();


            
            

        }
    }

    public class PackageConfiguration : IEntityTypeConfiguration<Package>
    {
        public void Configure(EntityTypeBuilder<Package> builder)
        {
            builder.ToTable("Package", schema: "App");
            builder.HasKey(x => x.Id);

            builder.Property(t => t.Id)
                   .HasColumnType("int")
                   .HasColumnName("PackageId");

            builder.Property(t => t.Title)
                    .HasColumnType("nvarchar(250)")
                    .HasColumnName("Title")
                    .IsRequired();

            builder.Property(t => t.description)
                    .HasColumnType("nvarchar(max)")
                    .HasColumnName("Description");

            builder.Property(t => t.Price)
                   .HasColumnType("decimal(18,2)")
                   .HasColumnName("Price")
                   .IsRequired();

            builder.HasMany(t => t.Subscriptions)
                .WithOne(r => r.package)
                .HasForeignKey(p => p.packageId)
                .OnDelete(DeleteBehavior.NoAction);
            builder.HasMany(t => t.PackageFeature_details)
             .WithOne(r => r.package)
             .HasForeignKey(p => p.PackageId)
             .OnDelete(DeleteBehavior.Cascade);
        }
    }

    public class PackageFeaturesConfiguration : IEntityTypeConfiguration<PackageFeatures>
    {
        public void Configure(EntityTypeBuilder<PackageFeatures> builder)
        {
            builder.ToTable("PackageFeatures", schema: "App");
            builder.HasKey(x => x.Id);

            builder.Property(t => t.Id)
                   .HasColumnType("int")
                   .HasColumnName("PackageFeatureId");

            builder.Property(t => t.description)
                    .HasColumnName("Description")
                    .HasColumnType("nvarchar(max)")
                    .IsRequired();
 
            builder.HasMany(t => t.PackageFeature_details)
             .WithOne(r => r.PackageFeatures)
             .HasForeignKey(p => p.PackageFeatureId)
             .OnDelete(DeleteBehavior.NoAction);
        }
    }


    public class PackageFeature_detailsConfiguration : IEntityTypeConfiguration<PackageFeature_details>
    {
        public void Configure(EntityTypeBuilder<PackageFeature_details> builder)
        {
            builder.ToTable("PackageFeature_details", schema: "App");
            builder.HasKey(x => new { x.PackageId, x.PackageFeatureId });

            builder.Property(t => t.PackageId)
                   .HasColumnType("int")
                   .HasColumnName("PackageId");

            builder.Property(t => t.PackageFeatureId)
                    .HasColumnType("int")
                    .HasColumnName("PackageFeatureId");
        }
    }


    public class SubscriptionsConfiguration : IEntityTypeConfiguration<Subscriptions>
    {
        public void Configure(EntityTypeBuilder<Subscriptions> builder)
        {
            builder.ToTable("Subscriptions", schema: "App");
            builder.HasKey(x => new { x.Id, x.packageId });

            builder.Property(t => t.Id)
                   .HasColumnType("int")
                   .HasColumnName("Sno");

            builder.Property(t => t.packageId)
                    .HasColumnName("packageId")
                    .HasColumnType("int");
            //builder.Property(t => t.UserId)
            //        .HasColumnName("UserId")
            //        .HasColumnType("int");

            builder.Property(t => t.FromDate)
                    .HasColumnName("FromDate")
                    .HasColumnType("Datetime");
            builder.Property(t => t.ToDate)
                    .HasColumnName("ToDate")
                    .HasColumnType("Datetime");
            builder.Property(t => t.packgeType)
                    .HasColumnName("packgeType")
                    .HasColumnType("int");
            builder.Property(t => t.Cost)
                    .HasColumnName("Cost")
                    .HasColumnType("decimal(18,2)");
        }
    }






}

