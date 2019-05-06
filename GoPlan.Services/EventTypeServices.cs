using GoPlan.Data;
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

        public EventTypeServices(){}

        public bool CreateEventType (EventTypeModel model)
        {
            var entity =
                new Data.EventType()
                {
                    Name = model.Name
                };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.EventTypes.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<EventTypeModel> GetEventTypeList()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .EventTypes
                    .Select(e => new EventTypeModel
                    { 
                        ID = e.ID,
                        Name = e.Name,
                    }
                    );
                return query.ToArray();
            }

        }

        public EventTypeModel GetEventTypeByID(int ID)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.EventTypes.Single(e => e.ID == ID);
                return new EventTypeModel
                {
                    ID = entity.ID,
                    Name = entity.Name
                };
            }
        }

        public bool UpdateEventType(EventTypeModel model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.EventTypes.Single(e => e.ID == model.ID);

                entity.Name = model.Name;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteEventType (int ID)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.EventTypes.Single(e => e.ID == ID);
                ctx.EventTypes.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
