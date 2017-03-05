using Journals.Core;
using Journals.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Journal.Services
{
    public class JournalIssueService : IJournalIssueService
    {
        public string GetIssue()
        {
            return "success";
        }
    }
}
