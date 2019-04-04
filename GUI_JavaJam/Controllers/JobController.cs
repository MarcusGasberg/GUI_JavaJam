using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GUI_JavaJam.Data;
using GUI_JavaJam.Models;

namespace GUI_JavaJam.Controllers
{
    public class JobController : Controller
    {
        private readonly ApplicationDbContext _context;

        public JobController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Job
        public async Task<IActionResult> Index()
        {
            return View(await _context.JobApplicantModel.ToListAsync());
        }

        // GET: Job/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var jobApplicantModel = await _context.JobApplicantModel
                .FirstOrDefaultAsync(m => m.Id == id);
            if (jobApplicantModel == null)
            {
                return NotFound();
            }

            return View(jobApplicantModel);
        }

        // GET: Job/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Job/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ApplicantName,Email,Experience")] JobApplicantModel jobApplicantModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(jobApplicantModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index),"Home");
            }
            return View(jobApplicantModel);
        }

        // GET: Job/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var jobApplicantModel = await _context.JobApplicantModel.FindAsync(id);
            if (jobApplicantModel == null)
            {
                return NotFound();
            }
            return View(jobApplicantModel);
        }

        // POST: Job/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ApplicantName,Email,Experience")] JobApplicantModel jobApplicantModel)
        {
            if (id != jobApplicantModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(jobApplicantModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!JobApplicantModelExists(jobApplicantModel.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(jobApplicantModel);
        }

        // GET: Job/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var jobApplicantModel = await _context.JobApplicantModel
                .FirstOrDefaultAsync(m => m.Id == id);
            if (jobApplicantModel == null)
            {
                return NotFound();
            }

            return View(jobApplicantModel);
        }

        // POST: Job/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var jobApplicantModel = await _context.JobApplicantModel.FindAsync(id);
            _context.JobApplicantModel.Remove(jobApplicantModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool JobApplicantModelExists(int id)
        {
            return _context.JobApplicantModel.Any(e => e.Id == id);
        }
    }
}
