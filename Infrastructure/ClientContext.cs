using clientprj.Domain.Client;
using Microsoft.EntityFrameworkCore;

namespace clientprj.Infrastructure
{
    public class ClientContext : DbContext
    {
        public ClientContext(DbContextOptions<ClientContext> options)
            : base(options)
        {
        }

        public DbSet<Client> Clients { get; set; }

    }
}