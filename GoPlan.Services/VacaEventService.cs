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
    }
}
