using AutoMapper;
using Journals.Core.DomainModels;
using Journals.Core.Repository;
using Journals.Repository.DataContext;
using Journals.Repository.EntityModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Journals.Repository.Collection
{
    public class SubscriptionRepository : RepositoryBase<JournalsContext>, ISubscriptionRepository
    {
        public List<Journal> GetAllJournals()
        {
            List<Journal> result = null;
            try
            {
                using (DataContext)
                {
                    var resultEntities = from a in DataContext.Journals
                                 where a.Title != null
                                 select new { a.Id, a.Title, a.Description, a.User, a.UserId, a.ModifiedDate, a.FileName };

                    if (resultEntities == null)
                        return new List<Journal>();

                    List<JournalEntity> list = resultEntities.AsEnumerable()
                                              .Select(f => new JournalEntity
                                              {
                                                  Id = f.Id,
                                                  Title = f.Title,
                                                  Description = f.Description,
                                                  UserId = f.UserId,
                                                  User = f.User,
                                                  ModifiedDate = f.ModifiedDate,
                                                  FileName = f.FileName
                                              }).ToList();

                   return Mapper.Map<List<Journal>>(list);
                }
            }
            catch (Exception e)
            {
                OperationStatus.CreateFromException("Error fetching subscriptions: ", e); ;
            }

            return result;
        }

        public List<Subscription> GetJournalsForSubscriber(int userId)
        {
            try
            {
                using (DataContext)
                {
                    var subscriptions = DataContext.Subscriptions.Where(u => u.UserId == userId);
                    if (subscriptions != null)
                        return Mapper.Map<List<Subscription>>(subscriptions.ToList());
                }
            }
            catch (Exception e)
            {
                OperationStatus.CreateFromException("Error fetching subscriptions: ", e);
            }

            return new List<Subscription>();
        }

        public List<Subscription> GetJournalsForSubscriber(string userName)
        {
            try
            {
                using (DataContext)
                {
                    var subscriptions = DataContext.Subscriptions.Include("Journal").Where(u => u.User.UserName == userName);
                    if (subscriptions != null)
                         return Mapper.Map<List<Subscription>>(subscriptions.ToList());
                }
            }
            catch (Exception e)
            {
                OperationStatus.CreateFromException("Error fetching subscriptions: ", e); ;
            }

            return new List<Subscription>();
        }

        public OperationStatus AddSubscription(int journalId, int userId)
        {
            var opStatus = new OperationStatus { Status = true };
            try
            {
                using (DataContext)
                {
                    SubscriptionEntity s = new SubscriptionEntity();
                    s.JournalId = journalId;
                    s.UserId = userId;
                    var j = DataContext.Subscriptions.Add(s);
                    DataContext.SaveChanges();
                }
            }
            catch (Exception e)
            {
                opStatus = OperationStatus.CreateFromException("Error adding subscription: ", e);
            }

            return opStatus;
        }

        public OperationStatus UnSubscribe(int journalId, int userId)
        {
            var opStatus = new OperationStatus { Status = true };
            try
            {
                using (DataContext)
                {
                    var subscriptions = DataContext.Subscriptions.Where(u => u.JournalId == journalId && u.UserId == userId);

                    foreach (var s in subscriptions)
                    {
                        DataContext.Subscriptions.Remove(s);
                    }
                    DataContext.SaveChanges();
                }
            }
            catch (Exception e)
            {
                opStatus = OperationStatus.CreateFromException("Error deleting subscription: ", e);
            }

            return opStatus;
        }
    }
}