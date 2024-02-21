using Championship.DAL;
using Microsoft.EntityFrameworkCore;

namespace Championship.Test
{
    public class UnitTest1
    {
        [Fact]
        public void CanInsertChampionshipdb()
        {
            DbContextOptions<TeamContext> options = new DbContextOptionsBuilder<TeamContext>()
                .UseInMemoryDatabase(databaseName: "Championship")
                .Options;
            var team = new Team()
            {
                Name = "Team24",
                Town = "Town24",
                Defeats = 547,
                Draws = 478,
                GoalsConceded = 478,
                GoalsScored = 475,
                Wins = 0,
                players = new List<Player> { new Player() { Name = "Player43", Number = 1, Position = "Position" } }
            };
            using (var context = new TeamContext(options))
            {
                if (context.Teams is not null)
                {
                    context.Teams.Add(team);
                    context.SaveChanges();
                }
            }

            using (var context = new TeamContext(options))
            {
                Assert.Equal(1, context.Teams.CountAsync().Result);

                Assert.Equal("Name", context.Teams.SingleAsync().Result.Name);
            }

            team.Name = "SuperTeam";
            using(var context = new TeamContext(options))
            {
                context.Teams.Update(team);
                context.SaveChanges();
            }
            using (var context = new TeamContext(options))
            {
                Assert.Equal(1, context.Teams.CountAsync().Result);

                Assert.Equal("Name", context.Teams.SingleAsync().Result.Name);
            }

        }
    }
}