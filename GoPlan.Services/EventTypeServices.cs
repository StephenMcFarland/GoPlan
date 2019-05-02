using GoPlan.Models.EventTypeModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoPlan.Services
{
    public class EventTypeServices
    {
        private readonly Guid _userID;

        public EventTypeServices(Guid userID)
        {
            _userID = userID;
        }

        public bool CreateEventType (EventTypeCreate model)
        {

        }

        public IEnumerable<EventTypeRead> GetEventTypeList()
        {

        }

        public EventTypeDetails GetEventTypeByID(int ID)
        {

        }
        public bool UpdateEventType(EventTypeUpdate model)
        {

        }
    }
}
