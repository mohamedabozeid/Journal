using System.ComponentModel.DataAnnotations.Schema;

namespace Journals.Repository.EntityModels
{
    public class SubscriptionEntity
    {
        public int Id { get; set; }

        [ForeignKey("JournalId")]
        public JournalEntity Journal { get; set; }

        public int JournalId { get; set; }

        [ForeignKey("UserId")]
        public UserProfileEntity User { get; set; }

        public int UserId { get; set; }
    }
}