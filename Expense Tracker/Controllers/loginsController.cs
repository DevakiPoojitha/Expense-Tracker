using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Expense_Tracker.Models;
using Microsoft.DotNet.Scaffolding.Shared.Messaging;
using Azure.Messaging;

namespace Expense_Tracker.Controllers
{
    public class loginsController : Controller
    {
        private readonly ApplicationDbContext _context;

       
        public loginsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: logins
        public async Task<IActionResult> Index()
        {
            return View(await _context.login_1.ToListAsync());
        }

        // GET: logins/Details/5
       /* public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.login_1 == null)
            {
                return NotFound();
            }

            var login = await _context.login_1
                .FirstOrDefaultAsync(m => m.Id == id);
            if (login == null)
            {
                return NotFound();
            }

            return View(login);
        }
*/
        // GET: logins/Create
        public IActionResult Create()
        {
            return View();
        }
       
        // POST: logins/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(login login)
        {
            var returnLogin = await _context.login_1.FirstOrDefaultAsync(X => Equals(X.Username,login.Username));
            var returnSignup = await _context.SignUp_1.FirstOrDefaultAsync(X => Equals(X.Username,login.Username));

           

            var returnLoginPassword = await _context.login_1.FirstOrDefaultAsync(Y => Equals(Y.Password,login.Password));
            var returnSignupPassword = await _context.login_1.FirstOrDefaultAsync(Y => Equals(Y.Password,login.Password));

            if ((returnLogin == null) || (returnLoginPassword == null)|| (returnSignup == null) || (returnSignupPassword == null))
                return NotFound();
            else
            {

                return RedirectToAction(nameof(Index));
            }
        }

        

        // GET: logins/Edit/5
        /*   public async Task<IActionResult> Edit(int? id)
           {
               if (id == null || _context.login_1 == null)
               {
                   return NotFound();
               }

               var login = await _context.login_1.FindAsync(id);
               if (login == null)
               {
                   return NotFound();
               }
               return View(login);
           }
   */
        // POST: logins/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        /* [HttpPost]
         [ValidateAntiForgeryToken]
         public async Task<IActionResult> Edit(int id, [Bind("Id,Username,Password")] login login)
         {
             if (id != login.Id)
             {
                 return NotFound();
             }

             if (ModelState.IsValid)
             {
                 try
                 {
                     _context.Update(login);
                     await _context.SaveChangesAsync();
                 }
                 catch (DbUpdateConcurrencyException)
                 {
                     if (!loginExists(login.Id))
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
             return View(login);
         }*/

        // GET: logins/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.login_1 == null)
            {
                return NotFound();
            }

            var login = await _context.login_1
                .FirstOrDefaultAsync(m => m.Id == id);
            if (login == null)
            {
                return NotFound();
            }

            return View(login);
        }

        // POST: logins/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.login_1 == null)
            {
                return Problem("Entity set 'ApplicationDbContext.login_1'  is null.");
            }
            var login = await _context.login_1.FindAsync(id);
            if (login != null)
            {
                _context.login_1.Remove(login);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool loginExists(int id)
        {
          return _context.login_1.Any(e => e.Id == id);
        }
    }
}
