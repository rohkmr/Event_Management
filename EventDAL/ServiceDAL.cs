using EventCommon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventDAL
{
    public class ServiceDAL
    {
        public EventContext Context = new EventContext();
        public List<Event> GetAllEvents()
        {
            return Context.Events.ToList();
        }

        public void AddEvent(Event e)
        {
            Context.Events.Add(e);
            Context.SaveChanges();
        }

        public Event GetEventById(int? id)
        {
            return Context.Events.Find(id);
        }

        public List<Event> GetMyInvites(string email)
        {
            return Context.Events.Where(c => c.InvitedEmails.Contains(email)).ToList();
        }

        public List<Event> GetMyEvents(string email)
        {
            return Context.Events.Where(c => c.Email== email).ToList();
        }

        public void Edit(int id, Event collection)
        {
            Event f = Context.Events.FirstOrDefault(x => x.Id ==id);
            f.Date = collection.Date;
            f.Description = collection.Description;
            f.Duration = collection.Duration;
            f.InvitedEmails = collection.InvitedEmails;
            f.IsPrivate = collection.IsPrivate;
            f.Location = collection.Location;
            f.OtherDetails = collection.OtherDetails;
            f.StartTime = collection.StartTime;
            f.Title = collection.Title;
            Context.SaveChanges();
        }

        public List<Event> GetAllPublicEvents()
        {
            return Context.Events.Where(c => c.IsPrivate == false).ToList();
        }
    }
}
