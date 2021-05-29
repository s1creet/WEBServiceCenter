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

namespace ServiceCenter.Pages.shops
{
    public class EditModel : PageModel
    {
        private readonly ServiceCenter.Data.ServiceCenterContext _context;

        public EditModel(ServiceCenter.Data.ServiceCenterContext context)
        {
            _context = context;
        }

        [BindProperty]
        public ОбслуживаемыеМагазины ОбслуживаемыеМагазины { get; set; }

        public async Task<IActionResult> OnGetAsync(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            ОбслуживаемыеМагазины = await _context.ОбслуживаемыеМагазиныs.FirstOrDefaultAsync(m => m.КодМагазина == id);

            if (ОбслуживаемыеМагазины == null)
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

            _context.Attach(ОбслуживаемыеМагазины).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ОбслуживаемыеМагазиныExists(ОбслуживаемыеМагазины.КодМагазина))
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

        private bool ОбслуживаемыеМагазиныExists(long id)
        {
            return _context.ОбслуживаемыеМагазиныs.Any(e => e.КодМагазина == id);
        }
    }
}
