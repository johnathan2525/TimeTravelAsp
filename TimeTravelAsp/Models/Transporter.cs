using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TimeTravelAsp.Models
{
    public class Transporter
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Transporter Name")]
        public string Name { get; set; }

        public ICollection<Passenger> Passengers { get; set; }
    }
}