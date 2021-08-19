using homework_51_1.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace homework_51_1.Controllers
{
    public class OrdersController : Controller
    {
        private MobileContext _db;
        public OrdersController(MobileContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            List<Order> orders = _db.Orders.Include(o => o.Phone).ToList();
            return View(orders);
        }
        public IActionResult Create(int phoneId)
        {
            Phone phone = _db.Phones.FirstOrDefault(p => p.Id == phoneId);
            return View(new Order { Phone = phone });
        }
        [HttpPost]
        public IActionResult Create(Order order)
        {
            if (order != null)
            {
                _db.Orders.Add(order);
                _db.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}
