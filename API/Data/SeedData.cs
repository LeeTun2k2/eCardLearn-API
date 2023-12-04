using API.Data.Constants;
using API.Data.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace API.Data
{
    /// <summary>
    /// Seed data
    /// </summary>
    public static class SeedData
    {
        /// <summary>
        /// Seed data
        /// </summary>
        /// <param name="roleManager"></param>
        /// <returns></returns>
        public async static Task Seed(RoleManager<Role> roleManager)
        {
            await SeedRoles(roleManager);
        }

        private async static Task SeedRoles(RoleManager<Role> roleManager)
        {
            var defaultRole = roleManager.Roles?
                .OrderBy(x => x.Id)
                .FirstOrDefault();

            if (defaultRole != null)
            {
                return;
            }

            if (!await roleManager.RoleExistsAsync(UserRoles.Student))
            {
                var role = new Role
                {
                    Name = UserRoles.Student
                };

                await roleManager.CreateAsync(role);
            }

            if (!await roleManager.RoleExistsAsync(UserRoles.Teacher))
            {
                var role = new Role
                {
                    Name = UserRoles.Teacher
                };

                await roleManager.CreateAsync(role);
            }

            if (!await roleManager.RoleExistsAsync(UserRoles.Admin))
            {
                var role = new Role
                {
                    Name = UserRoles.Admin,
                };

                await roleManager.CreateAsync(role);
            }
        }

        /// <summary>
        /// Seed data
        /// </summary>
        /// <param name="service"></param>
        /// <returns></returns>
        public async static Task Seed(IServiceProvider service)
        {
            var dbContext = service.GetService<DataContext>();
            if (dbContext != null)
            {
                await SeedUsers(dbContext);
                await SeedOpenTriviaDBCategory(dbContext);
            }

        }

        private static async Task SeedOpenTriviaDBCategory(DataContext dbContext)
        {
            var data = dbContext.OpenTriviaDBCategory.FirstOrDefault();
            if (data != null)
            {
                return;
            }

            IList<OpenTriviaDBCategory> defaultData = new List<OpenTriviaDBCategory>
            {
                new OpenTriviaDBCategory { CategoryName = "General Knowledge", OpenTriviaId = 9 },
                new OpenTriviaDBCategory { CategoryName = "Entertainment: Books", OpenTriviaId = 10 },
                new OpenTriviaDBCategory { CategoryName = "Entertainment: Film", OpenTriviaId = 11 },
                new OpenTriviaDBCategory { CategoryName = "Entertainment: Music", OpenTriviaId = 12 },
                new OpenTriviaDBCategory { CategoryName = "Entertainment: Musicals & Theatres", OpenTriviaId = 13 },
                new OpenTriviaDBCategory { CategoryName = "Entertainment: Television", OpenTriviaId = 14 },
                new OpenTriviaDBCategory { CategoryName = "Entertainment: Video Games", OpenTriviaId = 15 },
                new OpenTriviaDBCategory { CategoryName = "Entertainment: Board Games", OpenTriviaId = 16 },
                new OpenTriviaDBCategory { CategoryName = "Science & Nature", OpenTriviaId = 17 },
                new OpenTriviaDBCategory { CategoryName = "Science: Computers", OpenTriviaId = 18 },
                new OpenTriviaDBCategory { CategoryName = "Science: Mathematics", OpenTriviaId = 19 },
                new OpenTriviaDBCategory { CategoryName = "Mythology", OpenTriviaId = 20 },
                new OpenTriviaDBCategory { CategoryName = "Sports", OpenTriviaId = 21 },
                new OpenTriviaDBCategory { CategoryName = "Geography", OpenTriviaId = 22 },
                new OpenTriviaDBCategory { CategoryName = "History", OpenTriviaId = 23 },
                new OpenTriviaDBCategory { CategoryName = "Politics", OpenTriviaId = 24 },
                new OpenTriviaDBCategory { CategoryName = "Art", OpenTriviaId = 25 },
                new OpenTriviaDBCategory { CategoryName = "Celebrities", OpenTriviaId = 26 },
                new OpenTriviaDBCategory { CategoryName = "Animals", OpenTriviaId = 27 },
                new OpenTriviaDBCategory { CategoryName = "Vehicles", OpenTriviaId = 28 },
                new OpenTriviaDBCategory { CategoryName = "Entertainment: Comics", OpenTriviaId = 29 },
                new OpenTriviaDBCategory { CategoryName = "Science: Gadgets", OpenTriviaId = 30 },
                new OpenTriviaDBCategory { CategoryName = "Entertainment: Japanese Anime & Manga", OpenTriviaId = 31 },
                new OpenTriviaDBCategory { CategoryName = "Entertainment: Cartoon & Animations", OpenTriviaId = 32 }
            };

            await dbContext.OpenTriviaDBCategory.AddRangeAsync(defaultData);
            await dbContext.SaveChangesAsync();
        }


        private static async Task SeedUsers(DataContext dbContext)
        {
            var data = dbContext.Admin.FirstOrDefault();
            if (data != null)
            {
                return;
            }

            IList<Admin> defaultData = new List<Admin>();
            defaultData.Add(new Admin { Email = "lequangtung2002@gmail.com", Name= "admin", UserName = "admin", IsActive = true, EmailConfirmed = true }) ;

            await dbContext.Admin.AddRangeAsync(defaultData);
            await dbContext.SaveChangesAsync();
        }
    }
}