using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoPlan.Models.VacationModels
{
    public class VacationCreate
    {
            public DateTime StartDate { get; set; }

            public DateTime EndDate { get; set; }

            public string Name { get; set; }

            [Required]
            [MinLength(2, ErrorMessage = "Please enter at least 2 characters.")]
            [MaxLength(1000, ErrorMessage = "There are too many characters in this field.")]
            public string Description { get; set; }

            public string[] Attendees { get; set; }

            public string ImageSource { get; set; }
        }
    }

