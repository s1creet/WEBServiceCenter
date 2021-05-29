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

namespace ServiceCenter.Pages.orders
{
    public class EditModel : PageModel
    {
        private readonly ServiceCenter.Data.ServiceCenterContext _context;

        public EditModel(ServiceCenter.Data.ServiceCenterContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Заказы Заказы { get; set; }

        public async Task<IActionResult> OnGetAsync(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Заказы = await _context.Заказыs
                .Include(з => з.КодВидаNavigation)
                .Include(з => з.КодМагазинаNavigation)
                .Include(з => з.КодСотрудникаNavigation).FirstOrDefaultAsync(m => m.ЗаказыId == id);

            if (Заказы == null)
            {
                return NotFound();
            }
           ViewData["КодВида"] = new SelectList(_context.ВидыНеисправностейs, "КодВида", "КодВида");
           ViewData["КодМагазина"] = new SelectList(_context.ОбслуживаемыеМагазиныs, "КодМагазина", "КодМагазина");
           ViewData["КодСотрудника"] = new SelectList(_context.Сотрудникиs, "КодСотрудника", "КодСотрудника");
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

            _context.Attach(Заказы).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ЗаказыExists(Заказы.ЗаказыId))
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

        private bool ЗаказыExists(long id)
        {
            return _context.Заказыs.Any(e => e.ЗаказыId == id);
        }
    }
}
