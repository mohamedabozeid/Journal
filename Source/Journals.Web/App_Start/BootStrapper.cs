﻿using Journals.Core.Services;
using System.Data.Entity;
using System.Linq;
using System.Web.Security;
using WebMatrix.WebData;

namespace Journals.Web
{
    public class BootStrapper 
    {

        IBootstrapperService _service;
        public BootStrapper(IBootstrapperService service)
        {
            _service = service;
            _service.ModelChanged += DBModelChanged;
        }

        private void DBModelChanged(object sender, System.EventArgs e)
        {
            if (!WebSecurity.Initialized)
                WebSecurity.InitializeDatabaseConnection("JournalsDB", "UserProfile", "UserId", "UserName", autoCreateTables: true);

            var roles = (SimpleRoleProvider)Roles.Provider;
            var membership = (SimpleMembershipProvider)Membership.Provider;

            if (!roles.RoleExists("Publisher"))
            {
                roles.CreateRole("Publisher");
            }
            if (!roles.RoleExists("Subscriber"))
            {
                roles.CreateRole("Subscriber");
            }

            if (membership.GetUser("pappu", false) == null)
            {
                membership.CreateUserAndAccount("pappu", "Passw0rd");
            }
            if (!roles.GetRolesForUser("pappu").Contains("Publisher"))
            {
                roles.AddUsersToRoles(new[] { "pappu" }, new[] { "Publisher" });
            }

            if (membership.GetUser("pappy", false) == null)
            {
                membership.CreateUserAndAccount("pappy", "Passw0rd");
            }
            if (!roles.GetRolesForUser("pappy").Contains("Subscriber"))
            {
                roles.AddUsersToRoles(new[] { "pappy" }, new[] { "Subscriber" });
            }

            if (membership.GetUser("daniel", false) == null)
            {
                membership.CreateUserAndAccount("daniel", "Passw0rd");
            }
            if (!roles.GetRolesForUser("daniel").Contains("Publisher"))
            {
                roles.AddUsersToRoles(new[] { "daniel" }, new[] { "Publisher" });
            }

            if (membership.GetUser("andrew", false) == null)
            {
                membership.CreateUserAndAccount("andrew", "Passw0rd");
            }
            if (!roles.GetRolesForUser("andrew").Contains("Subscriber"))
            {
                roles.AddUsersToRoles(new[] { "andrew" }, new[] { "Subscriber" });
            }

            if (membership.GetUser("serge", false) == null)
            {
                membership.CreateUserAndAccount("serge", "Passw0rd");
            }
            if (!roles.GetRolesForUser("serge").Contains("Subscriber"))
            {
                roles.AddUsersToRoles(new[] { "serge" }, new[] { "Subscriber" });
            }

            if (membership.GetUser("harold", false) == null)
            {
                membership.CreateUserAndAccount("harold", "Passw0rd");
            }
            if (!roles.GetRolesForUser("harold").Contains("Publisher"))
            {
                roles.AddUsersToRoles(new[] { "harold" }, new[] { "Publisher" });
            }
        }

    }
}