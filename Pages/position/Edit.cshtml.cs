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

namespace ServiceCenter.Pages.position
{
    public class EditModel : PageModel
    {
        private readonly ServiceCenter.Data.ServiceCenterContext _context;

        public EditModel(ServiceCenter.Data.ServiceCenterContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Должности Должности { get; set; }

        public async Task<IActionResult> OnGetAsync(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Должности = await _context.Должностиs.FirstOrDefaultAsync(m => m.КодДолжности == id);

            if (Должности == null)
            {
                return NotFound();
            }
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

            _context.Attach(Должности).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ДолжностиExists(Должности.КодДолжности))
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

        private bool ДолжностиExists(long id)
        {
            return _context.Должностиs.Any(e => e.КодДолжности == id);
        }
    }
}
