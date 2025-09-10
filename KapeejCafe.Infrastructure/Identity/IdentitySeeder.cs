using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KapeejCafe.Infrastructure.Identity
{
    public static class IdentitySeeder
    {
        public static async Task SeedAsync(IServiceProvider services)
        {
            var roleMgr = services.GetRequiredService<RoleManager<AppRole>>();
            string[] roles = ["Admin", "Empleado", "Cliente"];

            foreach (var r in roles)
                if (!await roleMgr.RoleExistsAsync(r))
                    await roleMgr.CreateAsync(new AppRole(r));
        }
    }
}
