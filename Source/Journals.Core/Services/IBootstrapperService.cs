using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Journals.Core.Services
{

    public interface IBootstrapperService
    {
        event EventHandler ModelChanged;
        void init();
    }
}
