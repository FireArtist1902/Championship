using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Championship.DAL
{
    public class Matches
    {
        public int Id { get; set; }

        public Team? Team1 { get; set; }

        public Team? Team2 { get; set; }

        public int GoalsScoredByTeam1 { get; set; }

        public int GoalsScoredByTeam2 { get; set; }

        public DateTime Date { get; set; }
    }
}
