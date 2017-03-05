using Journals.Core;
using Journals.Repository;
using Journals.Web.Controllers;
using Microsoft.Practices.Unity;
using System;
using System.Reflection;
using System.Linq;
using Journals.Web.Controllers;
using Journals.Core.Services;
using Journals.Core.Repository;

namespace Journals.Web.IoC
{
    public static class IoCMappingContainer
    {
        private static IUnityContainer _Instance = new UnityContainer();

        static IoCMappingContainer()
        {
        }

        public static IUnityContainer GetInstance()
        {
            _Instance.RegisterType<HomeController>();
            _Instance.RegisterType<PublisherController>();
            _Instance.RegisterType<SubscriberController>();
            _Instance.RegisterType<IssueController>();
            Type journalRepo = Type.GetType("Journals.Repository.Collection.JournalRepository, Journals.Repository");
            _Instance.RegisterType(typeof(IJournalRepository), journalRepo,new HierarchicalLifetimeManager());
            Type subscriptionRepo = Type.GetType("Journals.Repository.Collection.SubscriptionRepositor, Journals.Repository");
            _Instance.RegisterType(typeof(ISubscriptionRepository), subscriptionRepo,new HierarchicalLifetimeManager());
            _Instance.RegisterType<IStaticMembershipService, StaticMembershipService>(new HierarchicalLifetimeManager());
            Type service = Type.GetType("Journal.Services.JournalIssueService, Journal.Services");
            _Instance.RegisterType(typeof(IJournalIssueService), service, new HierarchicalLifetimeManager());
            return _Instance;
        }
    }
}