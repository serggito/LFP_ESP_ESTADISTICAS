using System;
using System.Collections.Generic;

#nullable disable

namespace Utilities.Models
{
    public class PartidoDisputado
    {
        public int Id { get; set; }
        public string Season { get; set; }
        public byte? Division { get; set; }
        public byte? Round { get; set; }
        public string LocalTeam { get; set; }
        public string VisitorTeam { get; set; }
        public byte? LocalGoals { get; set; }
        public byte? VisitorGoals { get; set; }
        public DateTime? Date { get; set; }
        public int? Timestamp { get; set; }
    }
}
