using GoPlan.Models.EventTypeModels;
using GoPlan.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace GoPlanAPI.Controllers
{
    [Authorize]
    public class EventTypeController : ApiController
    { 
        public IHttpActionResult GetAll()
        {
            EventTypeServices eventTypeServices = CreateEventType();
            var eventType = eventTypeServices.GetEventTypeList();
            return Ok(eventType);
        }

        public IHttpActionResult Get(int ID)
        {
            EventTypeServices eventTypeServices = CreateEventType();
            var eventType = eventTypeServices.GetEventTypeByID(ID);
            return Ok(eventType);
        }

        public IHttpActionResult Post(EventTypeModel eventType)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var services = CreateEventType();
            if (!services.CreateEventType(eventType))
                return InternalServerError();
            return Ok();
        }
        public IHttpActionResult Put(EventTypeModel eventType)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var service = CreateEventType();
            if (!service.UpdateEventType(eventType))
                return InternalServerError();
            return Ok();
        }
        public IHttpActionResult Delete(int ID)
        {
            var service = CreateEventType();

            if (!service.DeleteEventType(ID))
                return InternalServerError();
            return Ok();
        }
        private EventTypeServices CreateEventType()
        {
            var eventTypeServices = new EventTypeServices();
            return eventTypeServices;
        } 
    }
}
