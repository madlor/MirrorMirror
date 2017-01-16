using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MirrorMirror.Models.APIs; 

namespace MirrorMirror.Controllers
{
    public class HomeController : Controller
    {
        FaceApi faceApi = new FaceApi();
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Error()
        {
            return View();
        }

        [HttpPost]
        public async Task<string> VerifyFace([FromBody] string image)
        {
            
            return await faceApi.DetectFace(image);

        }

        /*
        [HttpPost]
        public ActionResult SaveSnapshot()
        {
            bool saved = false;
            if (Request.Form["base64data"] != null)
            {
                string image = Request.Form["base64data"].ToString();
                byte[] data = Convert.FromBase64String(image);
                var path = Path.Combine(Server.MapPath("~/Upload"), "snapshot.png");
                System.IO.File.WriteAllBytes(path, data);
                saved = true;
            }

            return Json(saved ? "image saved" : "image not saved");
        }
        */
    }
}
