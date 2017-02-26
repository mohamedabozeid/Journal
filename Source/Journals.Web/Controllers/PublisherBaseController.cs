using Journals.Web.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Medico.Web.Controllers
{
    [AuthorizeRedirect(Roles = "Publisher")]
    public class PublisherBaseController : BaseController
    {
       

    }
}
