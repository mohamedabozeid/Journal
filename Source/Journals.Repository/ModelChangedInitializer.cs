using Journals.Core.Repository;
using Journals.Repository.DataContext;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Journals.Repository
{
    public class ModelChangedInitializer : DropCreateDatabaseIfModelChanges<JournalsContext>, IModelChangedInitializer
    {
        public event EventHandler ModelChanged;
        public ModelChangedInitializer()
        {
            Database.SetInitializer<JournalsContext>(this);
        }

        protected override void Seed(JournalsContext context)
        {
            DataInitializer.Initialize(context);
            using (var context1 = new UsersContext())
            {
                context1.UserProfiles.Find(1);
            }
                
            if (ModelChanged != null)
            {
                ModelChanged(this, null);
            }
        }
    }
}
