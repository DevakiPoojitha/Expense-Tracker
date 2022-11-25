using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Expense_Tracker.Models;

namespace Expense_Tracker.Controllers
{
    public class SignUpsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SignUpsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: SignUps
        public async Task<IActionResult> Index()
        {
            return View(await _context.SignUp_1.ToListAsync());
        }

        // GET: SignUps/Details/5
       /* public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.SignUp_1 == null)
            {
                return NotFound();
            }

            var signUp = await _context.SignUp_1
                .FirstOrDefaultAsync(m => m.user_Id == id);
            if (signUp == null)
            {
                return NotFound();
            }

            return View(signUp);
        }*/

        // GET: SignUps/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: SignUps/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("user_Id,Email_id,Username,Password,Confirm_Password")] SignUp signUp)
        {
            if (ModelState.IsValid)
            {
                await _context.SignUp_1.AddAsync(signUp);
                await _context.SaveChangesAsync();
                var loginData = new login();
                if (signUp != null)
                {
                    loginData.Password = signUp.Password;
                    loginData.Username = signUp.Username;
                }
                await _context.login_1.AddAsync(loginData);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
                
            }
            return View(signUp);
        }

        // GET: SignUps/Edit/5
       /* public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.SignUp_1 == null)
            {
                return NotFound();
            }

            var signUp = await _context.SignUp_1.FindAsync(id);
            if (signUp == null)
            {
                return NotFound();
            }
            return View(signUp);
        }
*/
        // POST: SignUps/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
       /* [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("user_Id,Email_id,Username,Password,Confirm_Password")] SignUp signUp)
        {
            if (id != signUp.user_Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(signUp);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SignUpExists(signUp.user_Id))
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
            return View(signUp);
        }
*/
        // GET: SignUps/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.SignUp_1 == null)
            {
                return NotFound();
            }

            var signUp = await _context.SignUp_1
                .FirstOrDefaultAsync(m => m.user_Id == id);
            if (signUp == null)
            {
                return NotFound();
            }

            return View(signUp);
        }

        // POST: SignUps/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.SignUp_1 == null)
            {
                return Problem("Entity set 'ApplicationDbContext.SignUp_1'  is null.");
            }
            var signUp = await _context.SignUp_1.FindAsync(id);
            if (signUp != null)
            {
                _context.SignUp_1.Remove(signUp);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SignUpExists(int id)
        {
          return _context.SignUp_1.Any(e => e.user_Id == id);
        }
    }
}
