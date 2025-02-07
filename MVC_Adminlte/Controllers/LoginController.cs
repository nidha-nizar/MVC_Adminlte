using System.Diagnostics.Contracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVC_Adminlte.Data;
using MVC_Adminlte.Models;

namespace MVC_Adminlte.Controllers
{
    public class LoginController : Controller
    {
        private readonly ApplicationDbContext _context;
        public LoginController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult login()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult login(ViewModelLogin r)
        {
            if (ModelState.IsValid)
            {

               
                var filtered = from l in _context.reg_tb
                               where l.eamil == r.eamil && l.password == r.password
                               select l;
               

                    return new RedirectResult(url:  "/hospitals/Hospital_Index", permanent: true,
                           preserveMethod: true);


                

            }
            return View();
        }
        public IActionResult register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult register(registers obj)
        {
            if (ModelState.IsValid)
            {
                _context.reg_tb.Add(obj);
                _context.SaveChanges();
                return RedirectToAction(nameof(register));
            }
            return View();
        }

    }
}
