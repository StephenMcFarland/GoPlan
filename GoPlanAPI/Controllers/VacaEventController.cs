using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using GoPlan.Models.VacaEventModels;
using GoPlan.Services;
using Microsoft.AspNet.Identity;

namespace GoPlanAPI.Controllers
{
    [Authorize]
    public class VacaEventController : ApiController
    {
        private VacaEventService CreateVacaEventService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            return new VacaEventService(userId);
        }
        public IHttpActionResult Get()
        {
            VacaEventService vacaEventService = CreateVacaEventService();
            var vEvents = vacaEventService.GetVacaEvents();
            return Ok(vEvents);
        }

        public IHttpActionResult GetByVaca(int vacaId)
        {
            VacaEventService vacaEventService = CreateVacaEventService();
            var vEvents = vacaEventService.GetVacaEventsByVacation(vacaId);
            return Ok(vEvents);
        }

        public IHttpActionResult Get(int id)
        {
            VacaEventService vacaEventService = CreateVacaEventService();
            var vEvent = vacaEventService.GetVacaEventByID(id);

            return Ok(vEvent);
        }
        public IHttpActionResult Post(VacaEventCreate vacaEvent)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateVacaEventService();

            if (!service.CreateVacaEvent(vacaEvent))
                return InternalServerError();

            return Ok();
        }

        public IHttpActionResult Put(VacaEventDetailEdit vacaEvent)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateVacaEventService();

            if (!service.UpdateVacaEvent(vacaEvent))
                return InternalServerError();

            return Ok();
        }

        public IHttpActionResult Delete(int id)
        {
            var service = CreateVacaEventService();

            if (!service.DeleteVacaEvent(id))
                return InternalServerError();

            return Ok();
        }

    }
}
