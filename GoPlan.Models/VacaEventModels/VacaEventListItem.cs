using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoPlan.Models.VacaEventModels
{
    public class VacaEventListItem
    {
        public string EventType { get; set; }
        public string Location { get; set; }
        public string Vacation { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImageSource { get; set; }
        public DateTimeOffset StartDate { get; set; }
        public DateTimeOffset EndDate { get; set; }
        public decimal Cost { get; set; }
    }
}
