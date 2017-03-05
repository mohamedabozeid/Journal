using Journals.Core.Repository;
using Journals.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Journal.Services
{
    public class BootstrapperService : IBootstrapperService
    {
        private IModelChangedInitializer _dbInitializer;
        public event EventHandler ModelChanged;
        public BootstrapperService(IModelChangedInitializer dbInitializer)
        {
            _dbInitializer = dbInitializer;
            _dbInitializer.ModelChanged += DbModelChanged;
        }

        private void DbModelChanged(object sender, EventArgs e)
        {
            if(ModelChanged != null)
            {
                ModelChanged(sender, e);
            }
        }

        public void init()
        {
            throw new NotImplementedException();
        }
    }
}
