
using Microsoft.EntityFrameworkCore;

namespace RestWithASPNETUdemy.Model.Context
{
    public class PsqlContext : DbContext
    {
        public PsqlContext(){

        }
        public PsqlContext(DbContextOptions<PsqlContext> options): base(options){ }

        public DbSet<Person> person { get; set; }
    }
}