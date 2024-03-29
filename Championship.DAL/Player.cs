﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Championship.DAL
{
    public class Player
    {
        public int Id { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        public string Name { get; set; }

        public int Number { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        public string Position { get; set; }
    }
}
