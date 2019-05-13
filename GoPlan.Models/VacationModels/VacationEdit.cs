using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoPlan.Models.VacationModels
{
    public class VacationEdit
    {
        public int ID { get; set; }

        public string User { get; set; }

        public DateTimeOffset CreatedDate { get; set; }

        public DateTimeOffset StartDate { get; set; }

        public DateTimeOffset EndDate { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string[] Attendees { get; set; }

        public decimal TotalCost { get; set; }

        public string ImageSource { get; set; }

        public string EventList { get; set; }
    }
}
