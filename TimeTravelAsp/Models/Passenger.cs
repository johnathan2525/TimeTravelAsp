using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TimeTravelAsp.Models
{
    public class Passenger
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Passenger Name")]
        public string Name { get; set; }

        [Display(Name = "Position In Time")]
        [Required]
        [DataType(DataType.DateTime)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime PositionInTime { get; set; }
        

        [Required]
        public string Destination { get; set; }

        [Display(Name = "Transporter")]
        [ForeignKey("Transporter")]
        public int TransporterId { get; set; }
        public Transporter Transporter { get; set; }
    }
}