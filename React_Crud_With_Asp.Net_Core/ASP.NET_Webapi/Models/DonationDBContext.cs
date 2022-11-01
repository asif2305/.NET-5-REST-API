using Microsoft.EntityFrameworkCore;
namespace ASP.NET_Webapi.Models
{
    public class DonationDBContext : DbContext
    {
        public DonationDBContext(DbContextOptions<DonationDBContext> options) :
            base(options)
        {

        }
        public DbSet<DCandidate> Dandidates { get; set; }
    }
}
