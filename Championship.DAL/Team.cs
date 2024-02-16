using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Championship.DAL
{
    public class Team
    {
        [Key]
        public int Id { get; set; }

        [Column(TypeName = "nvarchar(50)")]

        public string? Name { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        public string? Town { get; set; }

        public int Wins { get; set; }

        public int Defeats { get; set; }

        public int Draws { get; set; }

        public int GoalsScored { get; set; }

        public int GoalsConceded { get; set; }

        public List<Player>? players { get; set; }
    }
}
