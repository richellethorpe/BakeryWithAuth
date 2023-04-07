using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Bakery.Models
{
    public class BakeryContext : IdentityDbContext<ApplicationUser>
    {
      
    }
}