using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ServiceCenter.Data;
using ServiceCenter.Models;

namespace ServiceCenter.Pages.employees
{
    public class EditModel : PageModel
    {
        private readonly ServiceCenter.Data.ServiceCenterContext _context;

        public EditModel(ServiceCenter.Data.ServiceCenterContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Сотрудники Сотрудники { get; set; }

        public async Task<IActionResult> OnGetAsync(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Сотрудники = await _context.Сотрудникиs
                .Include(с => с.КодДолжностиNavigation).FirstOrDefaultAsync(m => m.КодСотрудника == id);

            if (Сотрудники == null)
            {
                return NotFound();
            }
           ViewData["КодДолжности"] = new SelectList(_context.Должностиs, "КодДолжности", "КодДолжности");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Сотрудники).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!СотрудникиExists(Сотрудники.КодСотрудника))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool СотрудникиExists(long id)
        {
            return _context.Сотрудникиs.Any(e => e.КодСотрудника == id);
        }
    }
}
