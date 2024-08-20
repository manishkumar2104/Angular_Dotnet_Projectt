using CarRentalDAL.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace CarRentalDAL.DB
{
    public class AppDBContext : IdentityDbContext<IdentityUser>
    {
        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options) { }

        public DbSet<Car> Cars { get; set; }
        public DbSet<RentalAgreement> RentalAgreements { get; set; }    
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            var adminRoleId=Guid.NewGuid().ToString();
            var userRoleId=Guid.NewGuid().ToString();
            var adminUserId=Guid.NewGuid().ToString();
            SeedRoles(builder, adminRoleId, userRoleId);
            SeedUserData(builder: builder, adminUserId: adminUserId, adminRoleId: adminRoleId, userRoleId: userRoleId);
            
        }

        private static void SeedRoles(ModelBuilder builder, string adminRoleId, string userRoleId)
        {
            builder.Entity<IdentityRole>().HasData(
                new IdentityRole() { Id= adminRoleId, Name = "Admin", ConcurrencyStamp = "1", NormalizedName = "ADMIN" },
                new IdentityRole() { Id = userRoleId, Name = "User", ConcurrencyStamp = "2", NormalizedName = "USER" }
                );
        }


        private static void SeedUserData(ModelBuilder builder, string adminUserId, string adminRoleId, string userRoleId)
        {
            var hasher= new PasswordHasher<IdentityUser>();
            //creating user ID for users so that I Can seed them to userRole table also
            var normalUserId1 = Guid.NewGuid().ToString();
            var normalUserId2 = Guid.NewGuid().ToString();
            var normalUserId3 = Guid.NewGuid().ToString();
            var normalUserId4 = Guid.NewGuid().ToString();
            var normalUserId5 = Guid.NewGuid().ToString();
            //creating Admin and normal users
            builder.Entity<IdentityUser>().HasData(
                new IdentityUser()
                {
                    Id = adminUserId,
                    UserName = "Admin",
                    NormalizedUserName = "ADMIN",
                    Email = "admin@admin.com",
                    NormalizedEmail = "ADMIN@ADMIN.COM",
                    EmailConfirmed = true,
                    PhoneNumber= "1234567890",
                    PhoneNumberConfirmed = true,
                    PasswordHash = hasher.HashPassword(null!,"Admin@1234")
                },
                new IdentityUser()
                {
                    Id = normalUserId1,
                    UserName = "Aditi",
                    NormalizedUserName = "ADITI",
                    Email = "aditi@abc.com",
                    NormalizedEmail = "ADITI@ABC.COM",
                    EmailConfirmed = true,
                    PhoneNumber = "1111111111",
                    PhoneNumberConfirmed = true,
                    PasswordHash = hasher.HashPassword(null!, "Aditi@1234")
                },
                new IdentityUser()
                {
                    Id = normalUserId2,
                    UserName = "Manish",
                    NormalizedUserName = "MANISH",
                    Email = "manish@abc.com",
                    NormalizedEmail = "MANISH@ABC.COM",
                    EmailConfirmed = true,
                    PhoneNumber = "2222222222",
                    PhoneNumberConfirmed = true,
                    PasswordHash = hasher.HashPassword(null!, "Manish@1234")
                },
                new IdentityUser()
                {
                    Id = normalUserId3,
                    UserName = "Ankit",
                    NormalizedUserName = "ANKIT",
                    Email = "ankit@abc.com",
                    NormalizedEmail = "ANKIT@ABC.COM",
                    EmailConfirmed = true,
                    PhoneNumber = "3333333333",
                    PhoneNumberConfirmed = true,
                    PasswordHash = hasher.HashPassword(null!, "Ankit@1234")
                },
                new IdentityUser()
                {
                    Id = normalUserId4,
                    UserName = "Sachin",
                    NormalizedUserName = "SACHIN",
                    Email = "sachin@abc.com",
                    NormalizedEmail = "SACHIN@ABC.COM",
                    EmailConfirmed = true,
                    PhoneNumber = "4444444444",
                    PhoneNumberConfirmed = true,
                    PasswordHash = hasher.HashPassword(null!, "Sachin@1234")
                },
                new IdentityUser()
                {
                    Id = normalUserId5,
                    UserName = "Devesh",
                    NormalizedUserName = "DEVESH",
                    Email = "devesh@abc.com",
                    NormalizedEmail = "DEVESH@ABC.COM",
                    EmailConfirmed = true,
                    PhoneNumber = "5555555555",
                    PhoneNumberConfirmed = true,
                    PasswordHash = hasher.HashPassword(null!, "Devesh@1234")
                }
                );
            //mapping users and respective roles
            builder.Entity<IdentityUserRole<string>>().HasData(
                new IdentityUserRole<string>()
                {
                    RoleId = adminRoleId,
                    UserId = adminUserId,
                },
                new IdentityUserRole<string>
                {
                    RoleId = userRoleId,
                    UserId = normalUserId1
                },
                new IdentityUserRole<string>
                {
                    RoleId = userRoleId,
                    UserId = normalUserId2
                },
                new IdentityUserRole<string>
                {
                    RoleId = userRoleId,
                    UserId = normalUserId3
                },
                new IdentityUserRole<string>
                {
                    RoleId = userRoleId,
                    UserId = normalUserId4
                },
                new IdentityUserRole<string>
                {
                    RoleId = userRoleId,
                    UserId = normalUserId5 
                }
                );
        }
        
    }
}
