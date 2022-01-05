using System;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace Utilities.Models
{
    public class PartidoDisputado
    {
        public int Id { get; set; }

        public string Season { get; set; }

        public byte? Division { get; set; }

        public byte? Round { get; set; }

        [Display(Name = "Local Team")]
        public string LocalTeam { get; set; }

        [Display(Name = "Visitor Team")]
        public string VisitorTeam { get; set; }

        [Display(Name = "Local Goals")]
        public byte? LocalGoals { get; set; }

        [Display(Name = "Visitor Goals")]
        public byte? VisitorGoals { get; set; }

        public DateTime? Date { get; set; }

        public int Timestamp { get; set; }
    }
    /*
     PartidoDisputado vacio

    public class PartidoDisputado
    {
        public int Id { get; set; }
        public string Season { get; set; }
        public byte? Division { get; set; }
        public byte? Round { get; set; }

        [Display(Name = "Local Team")]
        public string LocalTeam { get; set; }
        public string VisitorTeam { get; set; }
        public byte? LocalGoals { get; set; }
        public byte? VisitorGoals { get; set; }
        public DateTime? Date { get; set; }
        public int Timestamp { get; set; }
    }

     */
}
