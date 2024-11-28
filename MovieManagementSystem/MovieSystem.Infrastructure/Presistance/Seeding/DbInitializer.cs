using brca.Core.Extensions;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MovieSystem.Domain.Entities.Commen;
using MovieSystem.Domain.Helper;
using MovieSystem.Infrastructure.Presistance.Models;

namespace MovieSystem.Infrastructure.Presistance.Seeding
{
    public class DbInitializer
    {
        private readonly ModelBuilder modelBuilder;

        public DbInitializer(ModelBuilder modelBuilder)
        {
            this.modelBuilder = modelBuilder;
        }


        public string adminRoleId { get; set; } = Guid.NewGuid().ToString();
        public string userRoleId { get; set; } = Guid.NewGuid().ToString();
        public string adminUserId { get; set; } = Guid.NewGuid().ToString();
 


        public void Seed()
        {
            SeedDataForRoles();
            //SeedDataForUser();
            SeedDataForRoleUser();
            SeedDataForPermissions();
            SeedDataForRolePermission();
            SeedDataForUserPermission();
            SeedDataForCategory();
            SeedDataForMovie();
            SeedDataForReviews();
           // SeedDataForLike();
            //SeedDataUserMovie();
            SeedDataCountry();
            SeedDataCast();
            SeedDataMovieCast();
            SeedDataPackage();
            SeedDataPackageFeatures();
            SeedDataPackageFeature_details();
           // SeedDataSubscriptions();
        }

        public void SeedDataForRoles()
        {
            modelBuilder.Entity<ApplicationRole>().HasData(
                new ApplicationRole { Id = adminRoleId, Name = "Administrators", NormalizedName = "ADMINISTRATORS" },
                new ApplicationRole { Id = userRoleId, Name = "Managers", NormalizedName = "MANAGERS" }
                //new Roles { Id = Guid.NewGuid().ToString(), Name = "Hr", NormalizedName = "HR" },
                //new Roles { Id = Guid.NewGuid().ToString(), Name = "Customers", NormalizedName = "CUSTOMERS" }
                );
        }

        public void SeedDataForUser()
        {
            var hasher = new PasswordHasher<ApplicationUser>();
            modelBuilder.Entity<ApplicationUser>().HasData(
                new Models.ApplicationUser
                {
                    Id = adminUserId,
                    Name = "admin",
                    UserName = "admin",
                    NormalizedUserName = "ADMIN",
                    Email = "admin@example.com",
                    NormalizedEmail = "ADMIN@EXAMPLE.COM",
                    EmailConfirmed = true,
                    PasswordHash = hasher.HashPassword(null, "Admin@123")
                }
            );
        }

        public void SeedDataForRoleUser()
        {
            //modelBuilder.Entity<IdentityUserRole<string>>().HasData(
            //            new IdentityUserRole<string> { UserId = adminUserId, RoleId = adminRoleId } 
                        
            //            );
        }

        public void SeedDataForPermissions()
        {
            modelBuilder.Entity<Permissions>().HasData(
                        new Permissions { Id = 1, Name = "Show" },
                        new Permissions { Id = 2, Name = "Add" },
                        new Permissions { Id = 3, Name = "Edite" },
                        new Permissions { Id = 4, Name = "Delete" },
                        new Permissions { Id = 5, Name = "Print" },
                        new Permissions { Id = 6, Name = "Export Data" }
                );
        }
        public void SeedDataForUserPermission()
        {
            modelBuilder.Entity<IdentityUserClaim<string>>().HasData(
                new IdentityUserClaim<string> { Id = 1, UserId = adminUserId, ClaimType = "Permission", ClaimValue = "ViewRecords" },
                new IdentityUserClaim<string> { Id = 2, UserId = adminUserId, ClaimType = "Permission", ClaimValue = "EditRecords" }
            );
        }

        public void SeedDataForRolePermission()
        {
            modelBuilder.Entity<IdentityRoleClaim<string>>().HasData(
                new IdentityRoleClaim<string>{ Id = 1, RoleId = adminRoleId, ClaimType = "Permission", ClaimValue = "ViewRecords" },
                new IdentityRoleClaim<string> { Id = 2, RoleId = adminRoleId, ClaimType = "Permission", ClaimValue = "EditRecords" }
            );
        }



        //public void SeedDataRolePermission()
        //{
        //    modelBuilder.Entity<Permissions>()
        //        .HasMany(m => m.Roles)
        //        .WithMany(r => r.Permissions)
        //        .UsingEntity(
        //        j=> {
        //            j.HasData(
        //                new{RolesId = 1,PermissionsId = 1},
        //                new{RolesId = 1,PermissionsId = 2},
        //                new{RolesId = 2,PermissionsId = 3},
        //                new{RolesId = 3,PermissionsId = 1},
        //                new{RolesId = 3,PermissionsId = 3}
        //                );
        //            }
        //        );
        //}

        public void SeedDataForCategory()
        {
            modelBuilder.Entity<Category>().HasData(
                        
                        new Category { Id = 1, Name = "Arabic Movies" },
                        new Category { Id = 2, Name = "English Movies" },
                        new Category { Id = 3, Name = "Action" },
                        new Category { Id = 4, Name = "Western Action Movies" },
                        new Category { Id = 5, Name = "Arabic Action Movies" },
                        new Category { Id = 6, Name = "Comedy", ParentId = 2 },
                        new Category { Id = 7, Name = "Animation", ParentId = 2 },
                        new Category { Id = 8, Name = "Romance", ParentId = 1 },
                        new Category { Id = 9, Name = "Dark Comedy", ParentId = 1 },
                        new Category { Id = 10, Name = "Fantasy", ParentId = 2 },
                        new Category { Id = 11, Name = "History", ParentId = 4 },
                        new Category { Id = 12, Name = "Cartoon", ParentId = 3 },
                        new Category { Id = 13, Name = "Drama", ParentId = 3 }
                );
        }

        public void SeedDataForMovie()
        {
            modelBuilder.Entity<Movie>().HasData(
                        new Movie { Id = 1, Name = "inception",Description="Action" ,
                            CategoryId = 10,IsFree = true, Image= "~/Image1", Video="~/Video1",
                            ReleaseDate = new DateTime(2016, 01, 09),
                            Duration = new TimeOnly(1,55,13),CountryId=4},
                        new Movie { Id = 2, Name = "The Dark Knight", Description="Action" , CategoryId = 3,IsFree = false, Image= "~/Image3", Video="~/Video2",
                        ReleaseDate = new DateTime(2016, 01, 09),
                            Duration = new TimeOnly(1, 55, 13),
                            CountryId = 4
                        },
                        new Movie { Id = 3, Name = "Batman", Description="Action", CategoryId = 2, IsFree = true, Image = "~/Image3", Video = "~/Video3",
                        ReleaseDate = new DateTime(2016, 01, 09),
                            Duration = new TimeOnly(1, 55, 13),
                            CountryId = 4
                        },
                        new Movie { Id = 4, Name = "The Shawshank Redemption", Description = "Action", CategoryId = 2, IsFree = false, Image = "~/Image4", Video = "~/Video4",
                        ReleaseDate = new DateTime(2016, 01, 09),
                            Duration = new TimeOnly(1, 55, 13),
                            CountryId = 4
                        },
                        new Movie { Id = 5, Name = "Forrest Gump", Description = "Action", CategoryId = 2, IsFree = false, Image = "~/Image4", Video = "~/Video4",
                        ReleaseDate = new DateTime(2016, 01, 09),
                            Duration = new TimeOnly(1, 55, 13),
                            CountryId = 4
                        },
                        new Movie { Id = 6, Name = "Fight Club", Description = "Action", CategoryId = 2, IsFree = false, Image = "~/Image4", Video = "~/Video4",
                        ReleaseDate = new DateTime(2016, 01, 09),
                            Duration = new TimeOnly(1, 55, 13),
                            CountryId = 4
                        },
                        new Movie { Id = 7, Name = "The Godfather", Description = "Action", CategoryId = 13, IsFree = false, Image = "~/Image4", Video = "~/Video4",
                        ReleaseDate = new DateTime(2016, 01, 09),
                            Duration = new TimeOnly(1, 55, 13),
                            CountryId = 4
                        }

                );
        }

        public void SeedDataForReviews()
        {
            modelBuilder.Entity<Reviews>().HasData(
                        new Reviews { Id = 1,Content= "Review1",Rate=5,Date=DateTime.Now,UserId = 1,MovieId = 1},
                        new Reviews { Id = 2,Content= "Review2",Rate=5,Date=DateTime.Now,UserId = 2,MovieId = 2},
                        new Reviews { Id = 3,Content= "Review3",Rate=5,Date=DateTime.Now,UserId = 3,MovieId = 3}

                );
        }

        //public void SeedDataForLike()
        //{
        //    modelBuilder.Entity<Like>().HasData(
        //                new Like { Id = 1, UserId = 1, Reviewid = 1, isLiked = 1},
        //                new Like { Id = 2, UserId = 2, Reviewid = 3, isLiked = 1 },
        //                new Like { Id = 3, UserId = 2, Reviewid = 2, isLiked = 1 });
        //}

        //public void SeedDataUserMovie()
        //{
        //    modelBuilder.Entity<Models.UserMovie>().HasData(
        //                new Models.UserMovie { MovieId = 1, UserId = adminUserId ,watchDate=DateTime.Now,lastSeen= DateTime.Now },
        //                new Models.UserMovie { MovieId = 2, UserId = adminUserId, watchDate = DateTime.Now, lastSeen = DateTime.Now },
        //                new Models.UserMovie { MovieId = 3, UserId = adminUserId, watchDate = DateTime.Now, lastSeen = DateTime.Now });
        //}

        public void SeedDataCountry()
        {
            modelBuilder.Entity<Country>().HasData(
                        new Country { Id = 1, Name = "Egypt" },
                        new Country { Id = 2, Name = "China" },
                        new Country { Id = 3, Name = "Germany" },
                        new Country { Id = 4, Name = "United States" },
                        new Country { Id = 5, Name = "Italy" },
                        new Country { Id = 6, Name = "Japan" },
                        new Country { Id = 7, Name = "India" },
                        new Country { Id = 8, Name = "France" });
        }

        public void SeedDataCast()
        {
            modelBuilder.Entity<Cast>().HasData(
                        new Cast { Id = 1, Name = "Ian Bonhôte", Type = CastType.Director, CountryId = 4 },
                        new Cast { Id = 2, Name = "Connor Schell", Type = CastType.Producer, CountryId = 4 },
                        new Cast { Id = 3, Name = "Ian Bonhôte", Type = CastType.Writer, CountryId = 4 },
                        new Cast { Id = 4, Name = "Alexandra Reeve Givens", Type = CastType.Cast, CountryId = 4 },
                        new Cast { Id = 5, Name = "Matthew Reeve", Type = CastType.Cast, CountryId = 4 },
                        new Cast { Id = 6, Name = "Will Reeve", Type = CastType.Cast, CountryId = 4 }
                        );
        }

        public void SeedDataMovieCast()
        {
            modelBuilder.Entity<MovieCast>().HasData(
                        new MovieCast { MovieId = 1, CastId = 1 },
                        new MovieCast { MovieId = 1, CastId = 2 },
                        new MovieCast { MovieId = 1, CastId = 3 },
                        new MovieCast { MovieId = 1, CastId = 4 },
                        new MovieCast { MovieId = 1, CastId = 5 },
                        new MovieCast { MovieId = 1, CastId = 6 }
                        );
        }

        public void SeedDataPackage()
        {
            modelBuilder.Entity<Package>().HasData(
                        new Package { Id = 1,
                            Title= "VIP Mobile", 
                            description = "Stream on 1 phone or tablet at a time | Ad-free VIP entertainment for less",
                            Price = 28.99
                        },
                        new Package
                        {
                            Id = 2,
                            Title = "VIP",
                            description = "Epic Shahid Originals, the best exclusive Arabic & Turkish series, movie premieres, Live TV and much more",
                            Price = 88.99
                        },
                        new Package
                        {
                            Id = 3,
                            Title = "VIP | BigTime",
                            description = "Riyadh & Jeddah Season live concerts and events, previous editions in addition to VIP entertainment and perks",
                            Price = 174.99
                        },
                        new Package
                        {
                            Id = 4,
                            Title = "VIP | Sports",
                            description = "Roshn Saudi League, WWE, live regional and international sports and VIP entertainment & perks",
                            Price = 299.99
                        },
                        new Package
                        {
                            Id = 5,
                            Title = "Ultimate",
                            description = "VIP entertainment, Riyadh Season live and previous editions, live regional & international sports",
                            Price = 389.99
                        });
        }

        public void SeedDataPackageFeatures()
        {
            modelBuilder.Entity<PackageFeatures>().HasData(
                        new PackageFeatures { Id = 1, description = "Ad-free" },
                        new PackageFeatures { Id = 2, description = "Watch on big screen" },
                        new PackageFeatures { Id = 3, description = "Arabic & non-Arabic content" },
                        new PackageFeatures { Id = 4, description = "Original & premium content" },
                        new PackageFeatures { Id = 5, description = "Arabic kids content" },
                        new PackageFeatures { Id = 6, description = "Access to the biggest local and international live sports" },
                        new PackageFeatures { Id = 7, description = "Live concerts and events" },
                        new PackageFeatures { Id = 8, description = "Live channels" }
                        );
        }

        public void SeedDataPackageFeature_details()
        {
            modelBuilder.Entity<PackageFeature_details>().HasData(
                        new PackageFeature_details { PackageId = 1, PackageFeatureId= 1},
                        new PackageFeature_details { PackageId = 1, PackageFeatureId= 2},
                        new PackageFeature_details { PackageId = 1, PackageFeatureId= 3},
                        new PackageFeature_details { PackageId = 1, PackageFeatureId= 4},
                        new PackageFeature_details { PackageId = 1, PackageFeatureId= 5},
                        new PackageFeature_details { PackageId = 1, PackageFeatureId= 6},
                        new PackageFeature_details { PackageId = 1, PackageFeatureId= 7},
                        new PackageFeature_details { PackageId = 1, PackageFeatureId= 8}
                        );
        }

        public void SeedDataSubscriptions()
        {
            modelBuilder.Entity<Subscriptions>().HasData(
                        new Subscriptions {Id=1
                        //,UserId=1
                        , packageId = 1,
                            FromDate= DateTime.Now, 
                            ToDate = DateTime.Now.AddYears(1).ToDateTime(),
                            packgeType=PackgeType.Annual,Cost=347.88},
                        new Subscriptions {Id=2
                        //,UserId=2
                        , packageId = 2,
                            FromDate= DateTime.Now,
                            ToDate = DateTime.Now.AddMonths(1).ToDateTime(),
                            packgeType=PackgeType.Monthly, Cost = 28.99}
                        );
        }


    }
}
 
 
 
//New
 
 
 