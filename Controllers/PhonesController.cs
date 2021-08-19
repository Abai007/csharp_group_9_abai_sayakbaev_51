using homework_51_1.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace homework_51_1.Controllers
{
    public class PhonesController : Controller
    {
        private readonly IHostingEnvironment appEnvironment;
        private MobileContext _db;

        public PhonesController(MobileContext db, IHostingEnvironment appEnvironment)
        {
            _db = db;
            this.appEnvironment = appEnvironment;
        }
        public IActionResult Index()
        {
            List<Phone> phones = _db.Phones.ToList();
            return View(phones);
        }
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Add(Phone phone)
        {
            if (phone != null)
            {
                _db.Phones.Add(phone);
                _db.SaveChanges();
            }
            return RedirectToAction("Index");
        }
        public IActionResult DownloadFile(int id)
        {
            var task = _db.Phones.FirstOrDefault(e => e.Id == id);
            FileInfo fInfo = new FileInfo($"Files/{task.Company}.pdf");
            if (fInfo.Exists)
            {
                string filePath = Path.Combine(appEnvironment.ContentRootPath, $"Files/{task.Company}.pdf");
                string fileType = "application/pdf";
                string fileName = $"{task.Company}.pdf";
                return PhysicalFile(filePath, fileType, fileName);
            }
            else
            {
                return new NotFoundResult();
            }
            
        }
    }
}
