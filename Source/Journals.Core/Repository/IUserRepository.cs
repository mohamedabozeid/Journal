using Journals.Core.DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Journals.Core.Repository
{
    public interface IUserRepository
    {
        UserProfile GetUserByUserName(string userName);

        void AddUser(UserProfile user);

    }
}
