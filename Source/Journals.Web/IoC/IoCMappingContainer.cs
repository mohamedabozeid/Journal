using Journals.Core;
using Journals.Repository;
using Journals.Web.Controllers;
using Microsoft.Practices.Unity;
using System;
using System.Reflection;
using System.Linq;

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

            _Instance.RegisterType<IJournalRepository, JournalRepository>(new HierarchicalLifetimeManager());
            _Instance.RegisterType<ISubscriptionRepository, SubscriptionRepository>(new HierarchicalLifetimeManager());
            _Instance.RegisterType<IStaticMembershipService, StaticMembershipService>(new HierarchicalLifetimeManager());
             AppDomain.CurrentDomain.Load("Journal.Services");
           // Type service = assembly.GetTypes().Where(t => t.FullName.Contains("JournalIssueService")).FirstOrDefault();
            //Type service = Type.GetType("Journal.Services.JournalIssueService");
            //_Instance.RegisterType(typeof(IJournalIssueService), service, new HierarchicalLifetimeManager());
            return _Instance;
        }
    }
}