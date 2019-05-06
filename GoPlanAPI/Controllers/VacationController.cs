using GoPlan.Models.VacationModels;
using GoPlan.Services;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace GoPlanAPI.Controllers
{
    [Authorize]
    public class VacationController : ApiController
    {
        public IHttpActionResult CreateVacation(VacationCreate model)
        {
            VacationService vacationService = CreateVacationService();
            var vacation = vacationService.CreateVacation(model);
            return Ok(vacation);
        }
        public IHttpActionResult GetVacations()
        {
            VacationService vacationService = CreateVacationService();
            var vacations = vacationService.GetVacations();
            return Ok(vacations);
        }

        public IHttpActionResult GetVacationByUser()
        {
            VacationService vacationService = CreateVacationService();
            var vacation = vacationService.GetVacationByUser();
            return Ok(vacation);
        }
        public IHttpActionResult UpdateVacation(VacationEdit model)
        {
            VacationService vacationService = CreateVacationService();
            var vacations = vacationService.UpdateVacation(model);
            return Ok();
        }

        public IHttpActionResult Delete(int ID)
        {
            VacationService vacationService = CreateVacationService();
            var vacations = vacationService.DeleteVacation(ID);
            return Ok();
        }
        private VacationService CreateVacationService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var VacationService = new VacationService(userId);
            return VacationService;
        }
    }
}
