using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KapeejCafe.Infrastructure.Identity
{
    public class RefreshToken
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public Guid AppUserId { get; set; }
        public string Token { get; set; } = default!;
        public DateTime ExpiresAt { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? RevokedAt { get; set; }

        public bool IsExpired => DateTime.UtcNow >= ExpiresAt;
        public bool IsActive => RevokedAt is null && !IsExpired;

        // Navegación
        public AppUser AppUser { get; set; } = default!;
    }
}
