using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ServiceCenter.Data;
using ServiceCenter.Models;

namespace ServiceCenter.Pages.orders
{
    public class DeleteModel : PageModel
    {
        private readonly ServiceCenter.Data.ServiceCenterContext _context;

        public DeleteModel(ServiceCenter.Data.ServiceCenterContext context)
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
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Заказы = await _context.Заказыs.FindAsync(id);

            if (Заказы != null)
            {
                _context.Заказыs.Remove(Заказы);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
