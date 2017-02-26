using Journals.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Journals.Model
{
    public class JournalIssuresListViewModel
    {
        public int JournalId { get; set; }
        public List<JournalIssueViewModel> Issues { get; set; }
    }
}
