using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System.Security.Claims;

namespace AkademikAi.Data.Seed
{
    public static class IdentityDataSeeder
    {
        public static async Task SeedIdentityDataAsync(IServiceProvider serviceProvider)
        {
            using var scope = serviceProvider.CreateScope();
            var userManager = scope.ServiceProvider.GetRequiredService<UserManager<IdentityUser>>();
            var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            var logger = scope.ServiceProvider.GetRequiredService<ILogger<IdentityUser>>();

            try
            {
                // Rolleri oluştur
                await CreateRolesAsync(roleManager, logger);

                // Kullanıcıları oluştur
                await CreateUsersAsync(userManager, logger);

                logger.LogInformation("Identity seed data başarıyla eklendi.");
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Identity seed data eklenirken hata oluştu.");
                throw;
            }
        }

        private static async Task CreateRolesAsync(RoleManager<IdentityRole> roleManager, ILogger logger)
        {
            var roles = new[] { "Admin", "Teacher", "Student" };

            foreach (var role in roles)
            {
                if (!await roleManager.RoleExistsAsync(role))
                {
                    await roleManager.CreateAsync(new IdentityRole(role));
                    logger.LogInformation($"Rol oluşturuldu: {role}");
                }
            }
        }

        private static async Task CreateUsersAsync(UserManager<IdentityUser> userManager, ILogger logger)
        {
            var users = new[]
            {
                new { Email = "admin@akademikai.com", Password = "Admin123!", Role = "Admin", Name = "Admin" },
                new { Email = "ogretmen@akademikai.com", Password = "Ogretmen123!", Role = "Teacher", Name = "Öğretmen" },
                new { Email = "ahmet@akademikai.com", Password = "Ahmet123!", Role = "Student", Name = "Ahmet" },
                new { Email = "ayse@akademikai.com", Password = "Ayse123!", Role = "Student", Name = "Ayşe" },
                new { Email = "mehmet@akademikai.com", Password = "Mehmet123!", Role = "Student", Name = "Mehmet" }
            };

            foreach (var userInfo in users)
            {
                var existingUser = await userManager.FindByEmailAsync(userInfo.Email);
                if (existingUser == null)
                {
                    var user = new IdentityUser
                    {
                        UserName = userInfo.Email,
                        Email = userInfo.Email,
                        EmailConfirmed = true,
                        PhoneNumberConfirmed = true
                    };

                    var result = await userManager.CreateAsync(user, userInfo.Password);
                    if (result.Succeeded)
                    {
                        await userManager.AddToRoleAsync(user, userInfo.Role);
                        logger.LogInformation($"Kullanıcı oluşturuldu: {userInfo.Email} ({userInfo.Role})");
                    }
                    else
                    {
                        logger.LogError($"Kullanıcı oluşturulamadı: {userInfo.Email} - {string.Join(", ", result.Errors.Select(e => e.Description))}");
                    }
                }
                else
                {
                    logger.LogInformation($"Kullanıcı zaten mevcut: {userInfo.Email}");
                }
            }
        }
    }
} 