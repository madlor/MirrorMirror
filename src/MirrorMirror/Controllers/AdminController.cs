using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MirrorMirror.Models.ViewModels.Admin;
using MirrorMirror.Models;
using MirrorMirror.Models.APIs;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace MirrorMirror.Controllers
{
    public class AdminController : Controller
    {
        // GET: /<controller>/
        public IActionResult Index()
        {
            if (KeyHandler.GetFaceApiKey() == "")
                return RedirectToAction(nameof(CreateFaceApiKey));
            else if (FaceApiConfiguration.GetPersonGroupID() == null)
                return RedirectToAction(nameof(CreatePersonGroup));
            else
                return View();
        }


        [HttpGet]
        public IActionResult CreateFaceApiKey()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateFaceApiKey(CreateFaceApiKeyVM createFaceApiKey)
        {
            if (!ModelState.IsValid)
            {
                return View(createFaceApiKey);
            }
            KeyHandler.SetFaceApiKey(createFaceApiKey.ApiKey);
            return RedirectToAction(nameof(CreatePersonGroup));
        }


        [HttpGet]
        public IActionResult CreatePersonGroup()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreatePersonGroup(CreatePersonGroupVM createPersonGroup)
        {
            if (!ModelState.IsValid)
            {
                return View(createPersonGroup);
            }
            FaceApiConfiguration.SetPersonGroupID(createPersonGroup.PersonGroupID, createPersonGroup.PersonGroupName);
            return RedirectToAction(nameof(Index));
        }
    }
}
