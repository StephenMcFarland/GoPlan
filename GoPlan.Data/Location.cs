using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoPlan.Data
{
    public class Location
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public string Country { get; set; }
        [Required]
        public string State { get; set; }
        [Required]
        public string City { get; set; }
        public string Planet { get; set; }
        public string GoogleLocID { get; set; }

    }
}
