using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoPlan.Models.VacaEventModels
{
    public class VacaEventCreate
    {
        public int VacationID { get; set; }
        [Required]
        public int EventTypeID { get; set; }
        [Required]
        public int LocationID { get; set; }
        [Required]
        [MinLength(2, ErrorMessage = "Name must include at least 2 characters.")]
        [MaxLength(25, ErrorMessage = "Name cannot exceed 25 characters.")]
        public string Name { get; set; }
        [Required]
        [MaxLength(1000, ErrorMessage = "Name cannot exceed 1000 characters.")]
        public string Description { get; set; }
        public string ImageSource { get; set; }
        [Required]
        public DateTimeOffset StartDate { get; set; }
        public DateTimeOffset EndDate { get; set; }
        public decimal Cost { get; set; }
    }
}
