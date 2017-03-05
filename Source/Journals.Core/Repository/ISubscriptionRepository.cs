using Journals.Core.DomainModels;
using System.Collections.Generic;

namespace Journals.Core.Repository
{
    public interface ISubscriptionRepository
    {
        List<Journal> GetAllJournals();

        OperationStatus AddSubscription(int journalId, int userId);

        List<Subscription> GetJournalsForSubscriber(int userId);

        OperationStatus UnSubscribe(int journalId, int userId);

        List<Subscription> GetJournalsForSubscriber(string userName);
    }
}