using System.Collections.Generic;
using Journals.Core.DomainModels;

namespace Journals.Core
{
    public interface IJournalRepository
    {
        List<Journal> GetAllJournals(int userId);

        OperationStatus AddJournal(Journal newJournal);

        Journal GetJournalById(int Id);

        OperationStatus DeleteJournal(Journal journal);

        OperationStatus UpdateJournal(Journal journal);
    }
}