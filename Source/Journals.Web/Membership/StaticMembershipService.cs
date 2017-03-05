using System;
using System.Web.Security;
using WebMatrix.WebData;

namespace Journals.Repository
{
    public class StaticMembershipService : IStaticMembershipService
    {

        public bool IsUserInRole(string userName, string roleName)
        {
            var roles = (SimpleRoleProvider)Roles.Provider;
            return roles.IsUserInRole(userName, roleName);
        }

        public MembershipUser GetUser()
        {
            return Membership.GetUser();
        }
    }
}