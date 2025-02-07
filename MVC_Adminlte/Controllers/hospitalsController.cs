using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MVC_Adminlte.Data;
using MVC_Adminlte.Models;

namespace MVC_Adminlte
{
    public class hospitalsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public hospitalsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: hospitals
        public async Task<IActionResult> Index()
        {
            return View(await _context.hospital_tb.ToListAsync());
        }

        // GET: hospitals/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hospital = await _context.hospital_tb
                .FirstOrDefaultAsync(m => m.h_id == id);
            if (hospital == null)
            {
                return NotFound();
            }

            return View(hospital);
        }

        // GET: hospitals/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: hospitals/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("h_id,name,loc,email,phone")] hospital hospital)
        {
            if (ModelState.IsValid)
            {
                _context.Add(hospital);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(hospital);
        }

        // GET: hospitals/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hospital = await _context.hospital_tb.FindAsync(id);
            if (hospital == null)
            {
                return NotFound();
            }
            return View(hospital);
        }

        // POST: hospitals/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("h_id,name,loc,email,phone")] hospital hospital)
        {
            if (id != hospital.h_id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(hospital);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!hospitalExists(hospital.h_id))
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
            return View(hospital);
        }

        // GET: hospitals/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hospital = await _context.hospital_tb
                .FirstOrDefaultAsync(m => m.h_id == id);
            if (hospital == null)
            {
                return NotFound();
            }

            return View(hospital);
        }

        // POST: hospitals/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var hospital = await _context.hospital_tb.FindAsync(id);
            if (hospital != null)
            {
                _context.hospital_tb.Remove(hospital);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool hospitalExists(int id)
        {
            return _context.hospital_tb.Any(e => e.h_id == id);
        }
        public IActionResult Hospital_index()
        {
            return View();
          
        }
        public async Task<IActionResult> Reg_View()
        {
            //var objList = _context.reg_tb.ToList();
            //return View(objList);
            var q = from c in _context.reg_tb where c.status == "pending" select c;
            return View(q.ToList());


        }
        public async Task<IActionResult>approve(int id)
        {
            _context.reg_tb.Where(x => x.r_id == id).ToList().ForEach(x => x.status = "approve");
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        



        }
        public async Task<IActionResult> reject(int id)
        {
            _context.reg_tb.Where(x => x.r_id == id).ToList().ForEach(x => x.status = "reject");
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));




        }


    }
    }
