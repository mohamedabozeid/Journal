using Journals.Repository.EntityModels;
using System.Data.Entity;

namespace Journals.Repository.DataContext
{
    public class UsersContext : DbContext
    {
        public UsersContext()
            : base("JournalsDB")
        {
        }

        public DbSet<UserProfileEntity> UserProfiles { get; set; }
    }
}