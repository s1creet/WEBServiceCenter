using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ServiceCenter.Data;
using ServiceCenter.Models;

namespace ServiceCenter.Pages.view
{
    public class DeleteModel : PageModel
    {
        private readonly ServiceCenter.Data.ServiceCenterContext _context;

        public DeleteModel(ServiceCenter.Data.ServiceCenterContext context)
        {
            _context = context;
        }

        [BindProperty]
        public ВидыНеисправностей ВидыНеисправностей { get; set; }

        public async Task<IActionResult> OnGetAsync(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            ВидыНеисправностей = await _context.ВидыНеисправностейs
                .Include(в => в.Запчасть2кодЗапчастиNavigation)
                .Include(в => в.Запчасть3кодЗапчастиNavigation)
                .Include(в => в.КодЗапчастиNavigation)
                .Include(в => в.КодМоделиNavigation).FirstOrDefaultAsync(m => m.КодВида == id);

            if (ВидыНеисправностей == null)
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

            ВидыНеисправностей = await _context.ВидыНеисправностейs.FindAsync(id);

            if (ВидыНеисправностей != null)
            {
                _context.ВидыНеисправностейs.Remove(ВидыНеисправностей);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
