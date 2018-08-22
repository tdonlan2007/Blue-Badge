using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Ghost.Models;
using Microsoft.AspNet.Identity;

namespace Ghost.WebMVC.Controllers
{
    [Authorize]
    public class GhostController : Controller
    {
        public ActionResult Index()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new GhostService(userId);
            var model = service.GetGhosts();

            return View(model);
        }

        public ActionResult Create()
        {
            return View();
        }

        //Add code here vvvv
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(GhostCreate model)
        {
            if (!ModelState.IsValid) return View(model);

            var service = CreateGhostService();

            if (service.CreateGhost(model))
            {
                TempData["SaveResult"] = "Your ghost encounter was created.";
                return RedirectToAction("Index");
            };

            ModelState.AddModelError("", "Ghost encounter could not be created.");

            return View(model);
        }

        public ActionResult Details(int id)
        {
            var svc = CreateGhostService();
            var model = svc.GetGhostById(id);

            return View(model);
        }

        public ActionResult Edit(int id)
        {
            var service = CreateGhostService();
            var detail = service.GetGhostById(id);
            var model =
                new GhostEdit
                {
                    GhostId = detail.GhostId,
                    Title = detail.Title,
                    Content = detail.Content
                };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, GhostEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.GhostId != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }

            var service = CreateGhostService();

            if (service.UpdateGhost(model))
            {
                TempData["SaveResult"] = "Your ghost experience was updated.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Your ghost experience could not be updated.");
            return View(model);
        }
        [Authorize(Roles = "Admin")]
        public ActionResult Delete(int id)
        {
            var svc = CreateGhostService();
            var model = svc.GetGhostById(id);

            return View(model);
        }
        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int id)
        {
            var service = CreateGhostService();

            service.DeleteGhost(id);

            TempData["SaveResult"] = "Your note was deleted";

            return RedirectToAction("Index");
        }

        public GhostService CreateGhostService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new GhostService(userId);
            return service;
        }
    }
}