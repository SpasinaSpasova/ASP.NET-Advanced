using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Watchlist.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            if (User?.Identity?.IsAuthenticated ?? false)
            {
                return RedirectToAction("All", "Movies");
            }
            return View();
        }

        [HttpGet]
        public IActionResult Upload()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Upload(IFormFileCollection files)
        {
            foreach (var file in files)
            {
                string fileName = file.FileName;

                using (MemoryStream ms=new MemoryStream())
                {
                    await file.CopyToAsync(ms);
                    byte[] data = ms.ToArray();

                    //can save this byte array in database
                }
            }


            var result = new
            {
                fileCount = files.Count,
                fileSize = files.Sum(x => x.Length)
            };

            return Ok(result);
        }
    }
}