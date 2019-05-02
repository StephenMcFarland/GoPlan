using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoPlan.Data
{
    public class EventType
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public string Name { get; set; }
    }

}
