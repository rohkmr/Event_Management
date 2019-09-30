using EventCommon;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventDAL
{
    public class EventContext :DbContext
    {
        private volatile Type _dependency;
        public EventContext() : base("EventContext")
        {
            _dependency = typeof(System.Data.Entity.SqlServer.SqlProviderServices);
            //            var ensureDLLIsCopied =
            //System.Data.Entity.SqlServer.SqlProviderServices.Instance;
            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<EventContext>());
        }

        //public DbSet<User> Users { set; get; }lo
        public DbSet<Event> Events { set; get; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    
    }
}
