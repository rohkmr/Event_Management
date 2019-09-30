using EventBusiness;
using EventCommon;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace EventManagement.Controllers
{
    public class EventController : Controller
    {
        public ServiceBusiness serviceBusiness = new ServiceBusiness();

        public ActionResult MyInvites()
        {
            var events = serviceBusiness.GetMyInvites(User.Identity.GetUserName());
            return View(events);
        }
        public ActionResult MyEvent()
        {
            var events = serviceBusiness.GetMyEvents(User.Identity.GetUserName());
            return View(events);
        }

      
        
        public ActionResult Index()
        {
            if (User.Identity.IsAuthenticated && User.Identity.GetUserName() == "myadmin@bookevents.com")
            {
                return RedirectToAction("Index", "Admin");
            }
            List<Event> Events =serviceBusiness.GetAllPublicEvents();
            return View(Events);
        }
        
        public ActionResult Details(int ?id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Event event1 = serviceBusiness.GetEventById(id);
            if (event1 == null)
            {
                return HttpNotFound();
            }
            return View(event1);
        }

        
        public ActionResult Create()
        {
            return View();
        }

     
        [HttpPost]
        public ActionResult Create(Event e)
        {
            try
            {
                e.Email = User.Identity.GetUserName();
                serviceBusiness.AddEvent(e);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Edit(int Id)
        {
            if ((User.Identity.GetUserName() == serviceBusiness.GetEventById(Id).Email) || User.Identity.GetUserName() == "myadmin@bookevents.com")
                return View();
            if (User.Identity.IsAuthenticated && User.Identity.GetUserName() == "myadmin@bookevents.com")
            {
                return RedirectToAction("Index", "Admin",new { id=Id});
            }
            return Content("Invalid User");
        }

        [HttpPost]
        public ActionResult Edit(int id, Event collection)
        {
            try
            {
                serviceBusiness.Edit(id, collection);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

      
    }
}
