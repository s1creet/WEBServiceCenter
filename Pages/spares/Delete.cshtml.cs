using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ServiceCenter.Data;
using ServiceCenter.Models;

namespace ServiceCenter.Pages.spares
{
    public class DeleteModel : PageModel
    {
        private readonly ServiceCenter.Data.ServiceCenterContext _context;

        public DeleteModel(ServiceCenter.Data.ServiceCenterContext context)
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

        public async Task<IActionResult> OnPostAsync(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Запчасти = await _context.Запчастиs.FindAsync(id);

            if (Запчасти != null)
            {
                _context.Запчастиs.Remove(Запчасти);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
