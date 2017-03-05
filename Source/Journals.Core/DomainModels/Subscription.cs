using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Journals.Core.DomainModels
{
    public class Subscription
    {
        public int Id { get; set; }

        
        public Journal Journal { get; set; }

        public int JournalId { get; set; }

        public UserProfile User { get; set; }

        public int UserId { get; set; }
    }
}
