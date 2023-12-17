﻿using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TIProjekt.Models
{
    public class PositionLevel
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        [MaxLength(50)]
        public string? Name { get; set; }
    }
}
