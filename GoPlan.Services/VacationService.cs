using GoPlan.Data;
using GoPlan.Models.VacationModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoPlan.Services
{
    public class VacationService
    {

        private readonly Guid _userId;

        public VacationService(){}

        public VacationService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateVacation(VacationCreate model)
        {
            var entity =
                new Vacation()
                {

                    StartDate = model.StartDate,
                    EndDate = model.EndDate,
                    Name = model.Name,
                    Description = model.Description,
                    Attendees = convertArrayToList(model.Attendees),
                    ImageSource = model.ImageSource
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Vacations.Add(entity);
                return ctx.SaveChanges() == 1;
            }


        }

        public IEnumerable<VacationListItem> GetVacationByUser()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Vacations
                        .Where(e => e.UserID == _userId)
                        .Select(
                            e =>
                                new VacationListItem
                                {
                                    StartDate = e.StartDate,
                                    EndDate = e.EndDate,
                                    Name = e.Name,
                                    Description = e.Description,
                                    TotalCost = e.TotalCost,
                                    Attendees = e.Attendees,
                                    ImageSource = e.ImageSource
                                }
                        );

                return query.ToArray();
            }
        }
        public IEnumerable<VacationAdminListItem> GetVacations()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Vacations
                        .Select(
                            e =>
                                new VacationAdminListItem
                                {
                                    ID = e.ID,
                                    UserID = e.UserID.ToString(),
                                    Name = e.Name,
                                    TotalCost = e.TotalCost,
                                    ImageSource = e.ImageSource
                                }
                        );

                return query.ToArray();
            }
        }

        public bool UpdateVacation(VacationEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Vacations
                        .Single(e => e.ID == model.ID && e.UserID == _userId);

                entity.StartDate = model.StartDate;
                entity.EndDate = model.EndDate;
                entity.Name = model.Name;
                entity.Description = model.Description;
                entity.Attendees = model.Attendees;
                entity.EventList = model.EventList;
                entity.TotalCost = model.TotalCost;
                entity.ImageSource = model.ImageSource;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteVacation(int ID)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Vacations
                        .Single(e => e.ID == ID && e.UserID == _userId);

                ctx.Vacations.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
        private List<string> convertArrayToList(string[] array)
        {
            var output = array.ToList();
            return output;
        }

    }
}

