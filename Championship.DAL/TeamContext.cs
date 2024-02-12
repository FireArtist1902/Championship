using Microsoft.EntityFrameworkCore;


namespace Championship.DAL
{
    public class TeamContext : DbContext
    {
        public DbSet<Team> Teams { get; set; } 

        public DbSet<Matches> Matches { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Championship;Integrated Security=True;Connect Timeout=30;");
        }
    }
}