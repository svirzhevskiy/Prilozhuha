using System;
using System.Collections.Generic;
using System.Linq;
using Application.Services;
using Domain;
using Microsoft.Extensions.Logging;

namespace Database.Seeders
{
    public class UserSeeder
    {
        public void Seed(AppDbContext context, IServiceProvider serviceProvider, ILogger<AppDbContext> logger)
        {
            logger.LogInformation("User seed started");

            try
            {
                var users = context.Set<User>();

                if (users.Any())
                    return;

                var hashService = serviceProvider.GetService(typeof(IHashService)) as IHashService;
                var roles = context.Roles.ToList();
                var userRoleId = roles.First(x => x.Title == "user").Id;
                var adminRoleId = roles.First(x => x.Title == "admin").Id;
                var data = GetUsers(hashService, userRoleId, adminRoleId);

                users.AddRange(data);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message + "\n" + ex.StackTrace);
            }
            finally
            {
                logger.LogInformation("User seed finished");
            }
        }

        private List<User> GetUsers(IHashService hash, Guid userRoleId, Guid adminRoleId)
        {
            return new()
            {
                new User { 
                    Id = Guid.NewGuid(),
                    Email = "visualstudio@gmail.com", Name = "Larry",
                    Password = hash.GetHash("pass"), Surname = "Dickson",
                    IsDeleted = false, RoleId = userRoleId
                },
                new User {
                    Id = Guid.NewGuid(),
                    Email = "admin", Name = "admin",
                    Password = hash.GetHash("admin"), Surname = "admin",
                    IsDeleted = false, RoleId = adminRoleId
                },
            };
        }
    }
}