using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ServiceCenter.Data;
using ServiceCenter.Models;

namespace ServiceCenter.Pages.position
{
    public class DeleteModel : PageModel
    {
        private readonly ServiceCenter.Data.ServiceCenterContext _context;

        public DeleteModel(ServiceCenter.Data.ServiceCenterContext context)
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

        public async Task<IActionResult> OnPostAsync(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Должности = await _context.Должностиs.FindAsync(id);

            if (Должности != null)
            {
                _context.Должностиs.Remove(Должности);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
