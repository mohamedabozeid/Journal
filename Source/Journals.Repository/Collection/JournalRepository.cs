using AutoMapper;
using Journals.Core;
using Journals.Core.DomainModels;
using Journals.Repository.DataContext;
using Journals.Repository.EntityModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Threading.Tasks;

namespace Journals.Repository.Collection
{
    public class JournalRepository : RepositoryBase<JournalsContext>, IJournalRepository
    {
        public List<Journal> GetAllJournals(int userId)
        {
            List<Journal> result = new List<Journal>();
            using (DataContext)
            {
                var entities = DataContext.Journals.Where(j => j.Id > 0 && j.UserId == userId).ToList();
                if (entities != null)
                {
                    foreach (var entity in entities)
                    {
                        result.Add(Mapper.Map<Journal>(entity));
                    }
                }
            }

            return result;
        }

        public Journal GetJournalById(int Id)
        {
            Journal result = null;
            using (DataContext)
            {
                JournalEntity entity = DataContext.Journals.SingleOrDefault(j => j.Id == Id);
                if (entity != null)
                {
                    result = Mapper.Map<Journal>(entity);
                }
            }

            return result;  
        }

        public OperationStatus AddJournal(Journal newJournal)
        {
            JournalEntity entity = Mapper.Map<JournalEntity>(newJournal);
            var opStatus = new OperationStatus { Status = true };
            try
            {
                using (DataContext)
                {
                    newJournal.ModifiedDate = DateTime.Now;
                    var j = DataContext.Journals.Add(entity);
                    DataContext.SaveChanges();
                }
            }
            catch (Exception e)
            {
                opStatus = OperationStatus.CreateFromException("Error adding journal: ", e);
            }

            return opStatus;
        }

        public OperationStatus DeleteJournal(Journal journal)
        {
            var opStatus = new OperationStatus { Status = true };
            try
            {
                using (DataContext)
                {
                    var subscriptions = DataContext.Subscriptions.Where(j => j.JournalId == journal.Id);
                    foreach (var subscription in subscriptions)
                    {
                        DataContext.Subscriptions.Remove(subscription);
                    }

                    var journalToBeDeleted = DataContext.Journals.Find(journal.Id);
                    DataContext.Journals.Remove(journalToBeDeleted);
                    DataContext.SaveChanges();
                }
            }
            catch (Exception e)
            {
                opStatus = OperationStatus.CreateFromException("Error deleting journal: ", e);
            }

            return opStatus;
        }

        public OperationStatus UpdateJournal(Journal journal)
        {
            var opStatus = new OperationStatus { Status = true };
            try
            {
                var j = DataContext.Journals.Find(journal.Id);
                if (journal.Title != null)
                    j.Title = journal.Title;

                if (journal.Description != null)
                    j.Description = journal.Description;

                if (journal.Content != null)
                    j.Content = journal.Content;

                if (journal.ContentType != null)
                    j.ContentType = journal.ContentType;

                if (journal.FileName != null)
                    j.FileName = journal.FileName;

                j.ModifiedDate = DateTime.Now;

                DataContext.Entry(j).State = EntityState.Modified;
                DataContext.SaveChanges();
            }
            catch (DbEntityValidationException e)
            {
                foreach (var eve in e.EntityValidationErrors)
                {
                    OperationStatus.CreateFromException(string.Format("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:", eve.Entry.Entity.GetType().Name, eve.Entry.State), e);
                }
            }
            catch (Exception e)
            {
                opStatus = OperationStatus.CreateFromException("Error updating journal: ", e);
            }

            return opStatus;
        }
    }
}