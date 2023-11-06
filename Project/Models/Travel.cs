using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Laboratorium3zadanie
{
    public class Travel
    {
        /*public Travel(int id, string name, DateTime startTime, DateTime endTime, string startPlace, string endPlace, string participants, string guide)
        {
            Id = id;
            Name = name;
            StartTime = startTime;
            EndTime = endTime;
            StartPlace = startPlace;
            EndPlace = endPlace;
            Participants = participants;
            Guide = guide;
        }*/


        [HiddenInput]
        public int Id { get; set; }

        [Required(ErrorMessage = "Proszę podać nazwe!")]
        [StringLength(maximumLength: 100, ErrorMessage = "Zbyt długia nazwa")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Proszę podać date rozpoczęcia!")]
        public DateTime? StartTime { get; set; }

        public DateTime? EndTime { get; set; }

        [Required(ErrorMessage = "Proszę podać miejsce rozpoczęcia!")]
        public string StartPlace { get; set; }

        public string EndPlace { get; set; }

        [Required]
        public string Participants { get; set; }

        [Required]
        public string Guide { get; set; }






    }
}
