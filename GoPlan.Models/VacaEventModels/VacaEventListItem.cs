using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoPlan.Models.VacaEventModels
{
    public class VacaEventListItem
    {
        public string TypeOfEvent { get; set; }
        public string LocationName { get; set; }
        public string GooglePlaceID { get; set; }
        public string VacationName { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImageSource { get; set; }
        public DateTimeOffset StartDate { get; set; }
        public DateTimeOffset EndDate { get; set; }
        public decimal Cost { get; set; }
    }
}
