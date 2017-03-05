using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Journals.Core.Repository
{
    public interface IModelChangedInitializer
    {
        event EventHandler ModelChanged;
    }
}
