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
        public async Task<JsonResult> VerifyFace([FromBody] string image)
        {
            var result = await faceApi.DetectFace(image);
            return Json(result);

        }
    }
}
