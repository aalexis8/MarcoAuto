using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MarcoAuto.Data;
using MarcoAuto.Models;
using Microsoft.AspNetCore.Mvc;

namespace MarcoAuto.Controllers
{
    public class ServiceTypeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ServiceTypeController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: ServiceTypes
        public IActionResult Index()
        {
            return View(_context.ServiceTypes.ToList());
        }

        // GET: ServiceTypes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST : ServiceTypes/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ServiceType serviceType)
        {
            if (ModelState.IsValid)
            {
                _context.Add(serviceType);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View(serviceType);
        }
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _context.Dispose();
            }
        }
    }
}