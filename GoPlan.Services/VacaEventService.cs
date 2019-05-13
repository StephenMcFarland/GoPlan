using GoPlan.Data;
using GoPlan.Models.VacaEventModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoPlan.Services
{
    public class VacaEventService
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
                VacationID = model.VacationID,
                UserID = _userId,
                Name = model.Name,
                Description = model.Description,
                EventTypeID = model.EventTypeID,
                LocationName = model.LocationName,
                GooglePlaceID = model.GooglePlaceID,
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

        //private string NameParser(int id, string type)
        //{
        //    using (var ctx = new ApplicationDbContext())
        //    {
        //        switch (type)
        //        {
        //            case "typeofevent":
        //                return ctx.EventTypes.Single(e => e.ID == id).Name;
        //            case "location":
        //                string[] array = new string[3];
        //                var entity = ctx.Locations.Single(e => e.ID == id);
        //                array[0] = entity.City;
        //                array[1] = entity.State;
        //                array[2] = entity.Country;
        //                array[3] = entity.Planet;
        //                string output = string.Join(", ", array);
        //                return output;
        //            case "vacation":
        //                return ctx.Vacations.Single(e => e.ID == id).Name;
        //            default:
        //                return "Nowhere";
        //        }
        //    }
        //}
        public IEnumerable<VacaEventListItem> GetVacaEvents()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = ctx.VacaEvents
                    .Select(e => new VacaEventListItem
                    {
                        ID = e.ID,
                        EventTypeID = e.EventTypeID,
                        LocationName = e.LocationName,
                        GooglePlaceID = e.GooglePlaceID,
                        VacationID = e.VacationID,
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
                        EventTypeID = e.EventTypeID,
                        LocationName = e.LocationName,
                        GooglePlaceID = e.GooglePlaceID,
                        VacationID = e.VacationID,
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

        public VacaEventDetailEdit GetVacaEventByID(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.VacaEvents.Single(e => e.ID == id);
                var userEntity = ctx.Users.FirstOrDefault(e => e.Id == entity.UserID.ToString());
                var detail = new VacaEventDetailEdit
                {
                    ID = entity.ID,
                    User = userEntity.UserName,
                    EventTypeID = entity.EventTypeID,
                    LocationName = entity.LocationName,
                    GooglePlaceID = entity.GooglePlaceID,
                    VacationID = entity.VacationID,
                    Name = entity.Name,
                    Description = entity.Description,
                    ImageSource = entity.ImageSource,
                    StartDate = entity.StartDate,
                    EndDate = entity.EndDate,
                    Cost = entity.Cost
                };

                return detail;
            }
        }

        public bool UpdateVacaEvent(VacaEventDetailEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                //may need to add user/admin edit authorization check?
                var entity = ctx.VacaEvents.Single(e => e.ID == model.ID);

                entity.EventTypeID = model.EventTypeID;
                entity.LocationName = model.LocationName;
                entity.GooglePlaceID = model.GooglePlaceID;
                entity.VacationID = model.VacationID;
                entity.Name = model.Name;
                entity.Description = model.Description;
                entity.ImageSource = model.ImageSource;
                entity.StartDate = model.StartDate;
                entity.EndDate = model.EndDate;
                entity.Cost = model.Cost;

                return ctx.SaveChanges() == 1;
            }
        }
        public bool DeleteVacaEvent(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                //may need to add user/admin edit authorization check?
                var entity = ctx.VacaEvents.Single(e => e.ID == id);
                ctx.VacaEvents.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }

    }
}
