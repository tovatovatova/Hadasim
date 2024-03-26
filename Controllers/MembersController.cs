using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using COVID_19_Hadasim_.Data;
using COVID_19_Hadasim_.Models;

namespace COVID_19_Hadasim_.Controllers
{
    public class MembersController : Controller
    {
        private readonly COVID_19_Hadasim_Context _context;

        public MembersController(COVID_19_Hadasim_Context context)
        {
            _context = context;
        }

        // GET: Members
        public async Task<IActionResult> Index()
        {
            return _context.Member != null ?
                          View(await _context.Member.ToListAsync()) :
                          Problem("Entity set 'COVID_19_Hadasim_Context.Member'  is null.");
        }

        // GET: Members/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Member == null)
            {
                return NotFound();
            }

            var member = await _context.Member
                .FirstOrDefaultAsync(m => m.Id == id);
            if (member == null)
            {
                return NotFound();
            }
            var vaccines = await _context.Vaccine.ToListAsync();
            vaccines=vaccines.Where(v=>v.MemberID==member.MemberId).OrderBy(v=>v.VaccineNumber).ToList();
            ViewBag.vaccines = vaccines;
            return View(member);
        }

        // GET: Members/Create
        public IActionResult Create()
        {

            return View();
        }

        // POST: Members/Create
       // POST: Members/Create
[HttpPost]
[ValidateAntiForgeryToken]
public async Task<IActionResult> Create([Bind("Id,MemberFirstName,MemberLastName,MemberId,MemberAddress,MemberCity,HouseNumber,BirthDate,MemberPhone,MemberMobilePhone,MemberImage,PositiveRes,RecoveryDate")] Member member)
{
    if (ModelState.IsValid)
    {
        _context.Add(member);
        await _context.SaveChangesAsync();
        TempData["SuccessMessage"] = "Member added successfully.";
        
        // Redirect to the AddVaccine action with the memberId
        return RedirectToAction("AddVaccine", new { memberId = member.MemberId });
    }
    return View(member);
}
        // GET: Members/AddVaccine
        public IActionResult AddVaccine(int? memberId)
        {
            if (memberId == null)
            {
                return NotFound();
            }

            // Pass the memberId to the view
            ViewBag.MemberId = memberId;

            return View();
        }


        // GET: Members/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var member = await _context.Member.FindAsync(id);
            if (member == null)
            {
                return NotFound();
            }

            return View(member);
        }

        // POST: Members/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,MemberFirstName,MemberLastName,MemberAddress,MemberCity,HouseNumber,BirthDate,MemberPhone,MemberMobilePhone,MemberImage,PositiveRes,RecoveryDate")] Member member)
        {
            if (id != member.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(member);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MemberExists(member.Id))
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
            return View(member);
        }

        // GET: Members/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Member == null)
            {
                return NotFound();
            }

            var member = await _context.Member
                .FirstOrDefaultAsync(m => m.Id == id);
            if (member == null)
            {
                return NotFound();
            }

            return View(member);
        }

        // POST: Members/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Member == null)
            {
                return Problem("Entity set 'COVID_19_Hadasim_Context.Member'  is null.");
            }
            var member = await _context.Member.FindAsync(id);
            if (member != null)
            {
                _context.Member.Remove(member);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MemberExists(int id)
        {
            return (_context.Member?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
