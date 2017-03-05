using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Journals.Repository.EntityModels
{
    public class JournalEntity
    {
        public int Id { get; set; }

        
        public string Title { get; set; }

        public string Description { get; set; }

        public string FileName { get; set; }

        public string ContentType { get; set; }

        public byte[] Content { get; set; }

        public DateTime ModifiedDate { get; set; }

        [ForeignKey("UserId")]
        public UserProfileEntity User { get; set; }

        public int UserId { get; set; }

        public ICollection<JournalIssueEntity> Issues { get; set; } 
    }
}