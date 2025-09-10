using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KapeejCafe.Infrastructure.Identity
{
    public class AppRole : IdentityRole<Guid>
    {
        public AppRole() : base() { }
        public AppRole(string name) : base(name) { }
    }
}
