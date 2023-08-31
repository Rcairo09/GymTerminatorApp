using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
namespace GymTerminatorApp.Models
{
    public static class MolderBuilderExtension
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            // Crear ROLES
            List<IdentityRole> roles = new List<IdentityRole>() {
                new IdentityRole { Name = "Administrador", NormalizedName = "ADMINISTRADOR" },
                new IdentityRole { Name = "Cliente", NormalizedName = "CLIENTE" },
                new IdentityRole { Name = "Entrenador", NormalizedName = "ENTRENADOR" }

            };
            modelBuilder.Entity<IdentityRole>().HasData(roles);

            // Crear USERS
            List<ApplicationUser> users = new List<ApplicationUser>() {
                new ApplicationUser {
                    UserName = "martinezjohnny324@gmail.com",
                    NormalizedUserName = "MARTINEZJOHNNY324@GMAIL.COM",
                    Email = "martinezjohnny324@gmail.com",
                    NormalizedEmail = "MARTINEZJOHNNY324@GMAIL.COM",
                    EmailConfirmed = true
                }

            };
            modelBuilder.Entity<ApplicationUser>().HasData(users);

            // Agregar contraseña a los usuarios
            var passwordHasher = new PasswordHasher<ApplicationUser>();
            users[0].PasswordHash = passwordHasher.HashPassword(users[0], "edu2002");
           

            // Agregar roles a usuario
            List<IdentityUserRole<string>> userRoles = new List<IdentityUserRole<string>>();
            userRoles.Add(new IdentityUserRole<string>
            {
                UserId = users[0].Id,
                RoleId = roles.First(q => q.Name == "Administrador").Id
            });
           
            modelBuilder.Entity<IdentityUserRole<string>>().HasData(userRoles);

        }

    }
}
