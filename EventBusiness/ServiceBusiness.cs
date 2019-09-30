using EventCommon;
using EventDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventBusiness
{
    public class ServiceBusiness
    {
        private ServiceDAL ContextBussiness = new ServiceDAL();

        public List<Event> GetAllEvents()
        {
            List<Event> events = ContextBussiness.GetAllEvents();
            return events;
        }

        public List<Event> GetMyInvites(string email)
        {
            return ContextBussiness.GetMyInvites(email);
        }

        public void AddEvent(Event e)
        {
            ContextBussiness.AddEvent(e);
        }

        public List<Event> GetMyEvents(string email)
        {
            return ContextBussiness.GetMyEvents(email);
        }

        public Event  GetEventById(int? id)
        {
            return ContextBussiness.GetEventById(id);

        }

        public void Edit(int id, Event collection)
        {
            ContextBussiness.Edit(id, collection);
        }

        public List<Event> GetAllPublicEvents()
        {
            List<Event> events = ContextBussiness.GetAllPublicEvents();
            return events;
        }
    }
}
