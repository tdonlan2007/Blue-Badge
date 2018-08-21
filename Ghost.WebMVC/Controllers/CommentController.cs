using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Ghost.Models;
using Microsoft.AspNet.Identity;

namespace Ghost.WebMVC.Controllers
{
    namespace ElevenNote.Web.Controllers
    {
        [Authorize]
        public class NoteController : Controller
        {
            public ActionResult Index()
            {


                return View();
            }

            public ActionResult Create()
            {
                return View();
            }
        }
    }
}