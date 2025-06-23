using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace caronomics.api.Data;

public class SecurityDbContext : IdentityDbContext
{
    public SecurityDbContext(DbContextOptions<SecurityDbContext> options) : base(options)
    {
    }
}