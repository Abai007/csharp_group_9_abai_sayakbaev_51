using homework_51_1.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace homework_51_1.Controllers
{
    public class PhonesController : Controller
    {
        private MobileContext _db;
        public PhonesController(MobileContext db)
        {
            _db = db;
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
    }
}
