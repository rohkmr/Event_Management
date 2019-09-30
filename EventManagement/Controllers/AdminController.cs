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
    public class AdminController : Controller
    {
        public ServiceBusiness serviceBusiness = new ServiceBusiness();
        // GET: Admin
        public ActionResult Index()
        {
            if (User.Identity.GetUserName() != "myadmin@bookevents.com")
                return RedirectToAction("Index", "Event");
            List<Event> Events = serviceBusiness.GetAllEvents();
            return View(Events);
            
        }

        public ActionResult Details(int? id)
        {
            if (User.Identity.GetUserName() != "myadmin@bookevents.com")
                return RedirectToAction("Index", "Event");
            if (id == null)
                return RedirectToAction("Details", "Event");
            int id2 =  id ?? default(int);

            return RedirectToAction("Details", "Event", new { id =id2 });
        }

        
        public ActionResult Edit(int id)
        {
            Event event1 = serviceBusiness.GetEventById(id);


            return View(event1);
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
