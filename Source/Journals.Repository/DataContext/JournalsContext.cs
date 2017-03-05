using Journals.Repository.EntityModels;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace Journals.Repository.DataContext
{
    public class JournalsContext : DbContext, IDisposedTracker
    {
        public JournalsContext()
            : base("name=JournalsDB")
        {
        }

        public DbSet<JournalEntity> Journals { get; set; }
        public DbSet<SubscriptionEntity> Subscriptions { get; set; }
        public DbSet<JournalIssueEntity> JournalIssues { get; set; }
        public bool IsDisposed { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            base.Configuration.LazyLoadingEnabled = false;
            //modelBuilder.Entity<Journal>().ToTable("Journals")
            //    .HasMany(j => j.Issues)
            //    .WithOptional(i => i.Journal)
            //    .HasForeignKey(i => i.JournalId);
            modelBuilder.Entity<SubscriptionEntity>().ToTable("Subscriptions");

            //JournalIssues
            modelBuilder.Entity<JournalIssueEntity>().ToTable("JournalIssues")
                .HasKey(c => c.Id)
                .Property(c => c.Title).IsRequired();
            modelBuilder.Entity<JournalIssueEntity>().Property(c=>c.Description).IsRequired();
            modelBuilder.Entity<JournalIssueEntity>().Property(c => c.Description).HasColumnAnnotation("DataType", DataType.MultilineText);
            modelBuilder.Entity<JournalIssueEntity>()
                .HasRequired(i => i.Journal)
                .WithMany(j => j.Issues);
                
                

            base.OnModelCreating(modelBuilder);
        }

        protected override void Dispose(bool disposing)
        {
            IsDisposed = true;
            base.Dispose(disposing);
        }
    }
}