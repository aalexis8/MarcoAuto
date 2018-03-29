using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Microsoft.EntityFrameworkCore;
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

        //Details : ServiceTypes/Details/1
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var serviceType = await _context.ServiceTypes.SingleOrDefaultAsync(m => m.Id == id);
            if (serviceType == null)
            {
                return NotFound();
            }

            return View(serviceType);
        }

        //Edit : ServiceTypes/Edit/1
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var serviceType = await _context.ServiceTypes.SingleOrDefaultAsync(m => m.Id == id);
            if (serviceType == null)
            {
                return NotFound();
            }

            return View(serviceType);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, ServiceType serviceType)
        {
            if (id != serviceType.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _context.Update(serviceType);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }

            return View(serviceType);
        }

        //Delete : ServiceTypes/Delete/1
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var serviceType = await _context.ServiceTypes.SingleOrDefaultAsync(m => m.Id == id);
            if (serviceType == null)
            {
                return NotFound();
            }

            return View(serviceType);
        }

        [HttpPost, ActionName("Delete")]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> RemoveServiceType(int id)
        {
            var serviceType = await _context.ServiceTypes.SingleOrDefaultAsync(m => m.Id == id);
            _context.ServiceTypes.Remove(serviceType);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
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