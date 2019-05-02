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

        private List<string> convertArrayToList(string[] array)
        {
            var output = array.ToList();
            return output;
        }

    }
}

