using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ServiceCenter.Data;
using ServiceCenter.Models;

namespace ServiceCenter.Pages.shops
{
    public class DeleteModel : PageModel
    {
        private readonly ServiceCenter.Data.ServiceCenterContext _context;

        public DeleteModel(ServiceCenter.Data.ServiceCenterContext context)
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

        public async Task<IActionResult> OnPostAsync(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            ОбслуживаемыеМагазины = await _context.ОбслуживаемыеМагазиныs.FindAsync(id);

            if (ОбслуживаемыеМагазины != null)
            {
                _context.ОбслуживаемыеМагазиныs.Remove(ОбслуживаемыеМагазины);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
