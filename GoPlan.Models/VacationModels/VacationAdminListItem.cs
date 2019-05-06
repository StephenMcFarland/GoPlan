using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoPlan.Models.VacationModels
{
    public class VacationAdminListItem
    {

            public int ID { get; set; }

            public string UserID { get; set; }
            public string Name { get; set; }

            public decimal TotalCost { get; set; }

            public string ImageSource { get; set; }
        }
    }

