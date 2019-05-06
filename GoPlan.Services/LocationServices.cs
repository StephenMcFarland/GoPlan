using GoPlan.Data;
using GoPlan.Models.LocationModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoPlan.Services
{
    public class LocationServices
    {

        public LocationServices()
        {

        }

        public bool CreateLocation(LocationModel model)
        {
            var entity =
                new Data.Location()
                {
                    //ID = model.ID,
                    Planet = model.Planet,
                    Country = model.Country,
                    State = model.State,
                    City = model.City
                };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Locations.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<LocationModel> GetLocationList()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .Locations
                    .Select(e => new LocationModel
                    {
                        //ID = e.ID,
                        Planet =e.Planet,
                        Country = e.Country,
                        State = e.State,
                        City = e.City
                    }
                    );
                return query.ToArray();
            }

        }

        public LocationModel GetLocationByID(int ID)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Locations.Single(e => e.ID == ID);
                return new LocationModel
                {
                    //ID = entity.ID,
                    Planet = entity.Planet,
                    City = entity.City,
                    Country = entity.Country,
                    State = entity.State

                };
            }
        }

        public bool UpdateLocation(LocationModel model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Locations.Single(e => e.ID == model.ID);

                //model.ID = entity.ID;
                model.Planet = entity.Planet;
                model.Country = entity.Country;
                model.City = entity.City;
                model.State = entity.State;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteLocation(int ID)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Locations.Single(e => e.ID == ID);
                ctx.Locations.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
