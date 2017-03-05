using Journals.Core.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Journals.Core.DomainModels;
using Journals.Repository.DataContext;
using Journals.Repository.EntityModels;
using AutoMapper;

namespace Journals.Repository.Collection
{
    public class UserRepository : IUserRepository
    {
        public UserProfile GetUserByUserName(string userName)
        {
            using (UsersContext db = new UsersContext())
            {
                UserProfileEntity entity = db.UserProfiles.FirstOrDefault(u => u.UserName.ToLower() == userName);
                if (entity != null)
                {
                    return Mapper.Map<UserProfile>(entity);
                }
                return null;
            }
        }

        public void AddUser(UserProfile user)
        {
            UserProfileEntity entity = Mapper.Map<UserProfileEntity>(user);
            using (UsersContext db = new UsersContext())
            {
                db.UserProfiles.Add(entity);
                db.SaveChanges();
            }
        }



    }
}
