using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Journals.Core.DomainModels
{
    public class Journal
    {
        public int Id { get; set; }

        
        public string Title { get; set; }

        
        public string Description { get; set; }

        public string FileName { get; set; }

        public string ContentType { get; set; }

        public byte[] Content { get; set; }

        public DateTime ModifiedDate { get; set; }

        
        public UserProfile User { get; set; }

        public int UserId { get; set; }

        public ICollection<JournalIssue> Issues { get; set; }
    }
}
