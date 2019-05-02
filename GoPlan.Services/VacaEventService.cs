using GoPlan.Data;
using GoPlan.Models.VacaEventModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoPlan.Services
{
    class VacaEventService
    {
        private readonly Guid _userId;

        public VacaEventService() { }

        public VacaEventService(Guid userId)
        {
            _userId = userId;
        }
        public bool CreateVacaEvent(VacaEventCreate model)
        {
            var entity = new VacaEvent()
            {
                UserID = _userId,
                Name = model.Name,
                Description = model.Description,
                EventTypeID = 0,
                LocationID = 0,
                ImageSource = model.ImageSource,
                StartDate = model.StartDate,
                EndDate = model.EndDate,
                Cost = model.Cost
            };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.VacaEvents.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        private string NameParser(int id, string type)
        {
            using (var ctx = new ApplicationDbContext())
            {
                switch (type)
                {
                    case "typeofevent":
                        return ctx.EventTypes.Single(e => e.ID == id).Name;
                    case "location":
                        string[] array = new string[3];
                        var entity = ctx.Locations.Single(e => e.ID == id);
                        array[0] = entity.City;
                        array[1] = entity.State;
                        array[2] = entity.Country;
                        array[3] = entity.Planet;
                        string output = string.Join(", ", array);
                        return output;
                    case "vacation":
                        return ctx.Vacations.Single(e => e.ID == id).Name;
                    default:
                        return "Nowhere";
                }
            }
        }
        public IEnumerable<VacaEventListItem> GetVacaEvents()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = ctx.VacaEvents
                    .Select(e => new VacaEventListItem
                    {
                        TypeOfEvent = NameParser(e.EventTypeID, "typeofevent"),
                        LocationName = NameParser(e.LocationID, "location"),
                        VacationName = NameParser(e.VacationID, "vacation"),
                        Name = e.Name,
                        Description = e.Description,
                        ImageSource = e.ImageSource,
                        StartDate = e.StartDate,
                        EndDate = e.EndDate,
                        Cost = e.Cost 
                    });
                return query.ToArray();
            }
        }

        public IEnumerable<VacaEventListItem> GetVacaEventsByVacation(int vacaID)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = ctx.VacaEvents.Where(e => e.VacationID == vacaID)
                    .Select(e => new VacaEventListItem
                    {
                        TypeOfEvent = NameParser(e.EventTypeID, "typeofevent"),
                        LocationName = NameParser(e.LocationID, "location"),
                        VacationName = NameParser(e.VacationID, "vacation"),
                        Name = e.Name,
                        Description = e.Description,
                        ImageSource = e.ImageSource,
                        StartDate = e.StartDate,
                        EndDate = e.EndDate,
                        Cost = e.Cost
                    });
                return query.ToArray();
            }
        }

    }
}
