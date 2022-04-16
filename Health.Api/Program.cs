using Health.Data.Database;
using Health.Data.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Health.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();

            using var scope = host.Services.CreateScope();

            var ctx = scope.ServiceProvider.GetRequiredService<DataContext>();
            var userMgr = scope.ServiceProvider.GetRequiredService<UserManager<IdentityUser>>();


            if (!ctx.Users.Any(x => x.Username == "saad"))
            {
                var user = new IdentityUser("saad") { Id = "saad", Email = "saad@test.com" };
                userMgr.CreateAsync(user, "password").GetAwaiter().GetResult();
                ctx.Add(new User { 
                    Id = "saad", 
                    Username = "saad", 
                    Created = DateTime.UtcNow.ToLocalTime(),
                    Image = "https://media-exp1.licdn.com/dms/image/C4D03AQHm8mOxlGfztw/profile-displayphoto-shrink_800_800/0/1626566788317?e=1655337600&v=beta&t=Zcjf9nUHQnS-Q4T1L_zpfFzQYcCbSmt-DD6Hozg_PSU"
                });
            }

            ctx.SaveChangesAsync().GetAwaiter().GetResult();
            host.Run();

            //var user = new IdentityUser("saad") { Id = "saad", Email = "saad@test.com" };
            //await _userManager.CreateAsync(user, "password");
            //await _ctx.Users.AddAsync(new Data.Models.User
            //{
            //    Id = user.Id,
            //    Username = user.UserName,
            //    Image = ""
            //});
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
