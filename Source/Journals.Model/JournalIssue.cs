﻿using Journals.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Journals.Model
{
    public class JournalIssue
    {
        public int Id { get; set; }

        
        public int JournalId { get; set; }

        public Journal Journal { get; set; }
        public DateTime? IssueDate { get; set; }
        
        [Required]
        public string Title { get; set; }

        
        public string Description { get; set; }

        public string FileName { get; set; }

        public string ContentType { get; set; }

        public byte[] Content { get; set; }

        public DateTime ModifiedDate { get; set; }

        public UserProfile User { get; set; }

        public int UserId { get; set; }

    }
}
