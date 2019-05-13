using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoPlan.Data
{
    public class Vacation
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public Guid UserID { get; set; }
        [Required]
        public DateTimeOffset CreatedDate { get; set; }
        [Required]
        public DateTimeOffset StartDate { get; set; }
        [Required]
        public DateTimeOffset EndDate { get; set; }
        [Required]
        public string Name { get; set; }

        public string Description { get; set; }

        public decimal TotalCost { get; set; }

        public string ImageSource { get; set; } = "none";

        public string EventList { get; set; } = "none";

        public string Attendees { get; set; }


    }
}
