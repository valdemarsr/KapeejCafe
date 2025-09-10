using KapeejCafe.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KapeejCafe.Infrastructure.Identity
{
    public class AppUser : IdentityUser<Guid>
    {
        // Navegación hacia el agregado de negocio (opcional, 1–1)
        public Cliente? Cliente { get; set; }

        // Tokens de actualización (1–N)
        public ICollection<RefreshToken> RefreshTokens { get; set; } = new List<RefreshToken>();
    }
}
