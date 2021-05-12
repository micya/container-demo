using Microsoft.EntityFrameworkCore;
using webapi.Models;

namespace webapi.Data
{
    public class PetContext : DbContext
    {
        public PetContext (DbContextOptions<PetContext> options)
            : base(options)
        {
        }

        public DbSet<Pet> Pets { get; set; }
    }
}