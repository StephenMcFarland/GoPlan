using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoPlan.Models.VacationModels
{
    public class VacationListItem
    {
        public DateTimeOffset StartDate { get; set; }

        public DateTimeOffset EndDate { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public decimal TotalCost { get; set; }

        public List<string> Attendees { get; set; }

        public string ImageSource { get; set; }

    }
}
