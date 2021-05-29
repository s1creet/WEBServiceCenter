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

namespace ServiceCenter.Pages.view
{
    public class EditModel : PageModel
    {
        private readonly ServiceCenter.Data.ServiceCenterContext _context;

        public EditModel(ServiceCenter.Data.ServiceCenterContext context)
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
           ViewData["Запчасть2кодЗапчасти"] = new SelectList(_context.Запчастиs, "КодЗапчасти", "КодЗапчасти");
           ViewData["Запчасть3кодЗапчасти"] = new SelectList(_context.Запчастиs, "КодЗапчасти", "КодЗапчасти");
           ViewData["КодЗапчасти"] = new SelectList(_context.Запчастиs, "КодЗапчасти", "КодЗапчасти");
           ViewData["КодМодели"] = new SelectList(_context.РемонтируемыеМоделиs, "КодМодели", "КодМодели");
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

            _context.Attach(ВидыНеисправностей).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ВидыНеисправностейExists(ВидыНеисправностей.КодВида))
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

        private bool ВидыНеисправностейExists(long id)
        {
            return _context.ВидыНеисправностейs.Any(e => e.КодВида == id);
        }
    }
}
