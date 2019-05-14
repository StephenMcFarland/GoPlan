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
            string attendees = "None";
            try { attendees = String.Join(",", model.Attendees); }
            catch (ArgumentNullException) { }

            var entity =
                new Vacation()
                {
                    UserID = _userId,
                    CreatedDate = DateTimeOffset.Now,
                    StartDate = model.StartDate,
                    EndDate = model.EndDate,
                    Name = model.Name,
                    Description = model.Description,
                    Attendees = attendees,
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
                        .AsEnumerable()
                        .Where(e => e.UserID == _userId)
                        .Select(
                            e =>
                                new VacationListItem
                                {
                                    ID = e.ID,
                                    User = ctx.Users.FirstOrDefault(u => u.Id == e.UserID.ToString()).UserName,
                                    CreatedDate = e.CreatedDate,
                                    StartDate = e.StartDate,
                                    EndDate = e.EndDate,
                                    Name = e.Name,
                                    Description = e.Description,
                                    TotalCost = e.TotalCost,
                                    Attendees = e.Attendees.Split(',').ToList(),
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
                                    User = ctx.Users.FirstOrDefault(u => u.Id == e.UserID.ToString()).UserName,
                                    Name = e.Name,
                                    TotalCost = e.TotalCost,
                                    ImageSource = e.ImageSource
                                }
                        );

                return query.ToArray();
            }
        }
        
        public VacationEdit GetVacation(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Vacations.Single(e => e.ID == id);
                var detail = new VacationEdit
                {
                    ID = entity.ID,
                    User = ctx.Users.FirstOrDefault(u => u.Id == entity.UserID.ToString()).UserName,
                    CreatedDate = entity.CreatedDate,
                    StartDate = entity.StartDate,
                    EndDate = entity.StartDate,
                    Name = entity.Name,
                    Description = entity.Description,
                    Attendees = entity.Attendees.Split(','),
                    ImageSource = entity.ImageSource,
                    EventList = entity.EventList,
                    TotalCost = entity.TotalCost
                };

                return detail;
            }
        }
        public bool UpdateVacation(VacationEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Vacations
                        .Single(e => e.ID == model.ID);

                entity.StartDate = model.StartDate;
                entity.EndDate = model.EndDate;
                entity.Name = model.Name;
                entity.Description = model.Description;
                entity.Attendees = String.Join(",", model.Attendees);
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
                        .Single(e => e.ID == ID);

                ctx.Vacations.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
        //private List<string> convertArrayToList(string[] array)
        //{
        //    var output = array.ToList();
        //    return output;
        //}

    }
}

