using Journals.Model;
using Journals.Web.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Medico.Web.Controllers
{
    public class IssueController : PublisherBaseController
    {


        public ActionResult Index(string id)
        {
            int int_id = int.Parse(CryptoEngine.Instance.Decrypt(id));
            var model = new JournalIssuresListViewModel()
            {
                JournalId = int_id,
                Issues = new List<JournalIssueViewModel>()
                { 
                    new JournalIssueViewModel() 
                    {
                        JournalId = int_id,
                        FileName = "xxx",
                        IssueId =1,
                        Title= "test xxx",
                        Description = "just for testing purposes"
                    },
                     new JournalIssueViewModel() 
                    {
                        JournalId = int_id,
                        FileName = "yyy",
                        IssueId =2,
                        Title= "test yyyy",
                        Description = "just for testing purposes, not real data"
                    } 

                }
            };

            return View(model);
        }

        public ActionResult Create(string id)
        {
            var model = new JournalIssueViewModel()
                 {
                     JournalId = 1,
                 };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(JournalIssueViewModel model)
        {
            if (ModelState.IsValid)
            {
                string id = Request.Params["id"];
                return RedirectToAction("Index", "Publisher");
            }
            else
                return View(model);
        }

        public ActionResult Edit(string id)
        {
            int int_id = int.Parse(CryptoEngine.Instance.Decrypt(id));
            var model = new JournalIssueViewModel()
                    {
                        JournalId = int_id,
                        FileName = "xxx",
                        IssueId = 1,
                        Title = "test xxx",
                        Description = "just for testing purposes"
                    };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(JournalIssueViewModel model)
        {
            if (ModelState.IsValid)
            {
                string id = Request.Params["id"];
                return RedirectToAction("Index", "Publisher");
            }
            else
                return View(model);
        }

        public ActionResult Delete(string id)
        {
            int int_id = int.Parse(CryptoEngine.Instance.Decrypt(id));
            var model = new JournalIssueViewModel()
            {
                JournalId = int_id,
                FileName = "xxx",
                IssueId = 1,
                Title = "test xxx",
                Description = "just for testing purposes"
            };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(JournalIssueViewModel model)
        {
            if (ModelState.IsValid)
            {
                string id = Request.Params["id"];
                return RedirectToAction("Index", "Publisher");
            }
            else
                return View(model);
        }

        public ActionResult GetFile(string id)
        {
            int int_id = int.Parse(CryptoEngine.Instance.Decrypt(id));
            // get issue by id3
            return null;

        }


    }
}
