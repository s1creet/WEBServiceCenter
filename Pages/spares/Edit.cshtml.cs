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

namespace ServiceCenter.Pages.spares
{
    public class EditModel : PageModel
    {
        private readonly ServiceCenter.Data.ServiceCenterContext _context;

        public EditModel(ServiceCenter.Data.ServiceCenterContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Запчасти Запчасти { get; set; }

        public async Task<IActionResult> OnGetAsync(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Запчасти = await _context.Запчастиs.FirstOrDefaultAsync(m => m.КодЗапчасти == id);

            if (Запчасти == null)
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

            _context.Attach(Запчасти).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ЗапчастиExists(Запчасти.КодЗапчасти))
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

        private bool ЗапчастиExists(long id)
        {
            return _context.Запчастиs.Any(e => e.КодЗапчасти == id);
        }
    }
}
