using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoPlan.Data
{
    public class VacaEvent
    {
        [Key]
        public int ID { get; set; }
        public Guid UserID { get; set; }
        [Required]
        public int EventTypeID { get; set; }

        public string LocationName { get; set; }

        public string GooglePlaceID { get; set; }

        [Required]
        public int VacationID { get; set; }
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImageSource { get; set; }
        [Required]
        public DateTimeOffset StartDate { get; set; }
        public DateTimeOffset EndDate { get; set; }
        public decimal Cost { get; set; }

    }
}
