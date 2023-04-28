using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ToDoLifeApp.Data;
using ToDoLifeApp.Models;

namespace ToDoLifeApp.Pages.ToDos
{
    public class DetailsModel : PageModel
    {
        private readonly ToDoLifeApp.Data.ApplicationDbContext _context;

        public DetailsModel(ToDoLifeApp.Data.ApplicationDbContext context)
        {
            _context = context;
        }

      public ToDo ToDo { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.ToDo == null)
            {
                return NotFound();
            }

            var todo = await _context.ToDo.FirstOrDefaultAsync(m => m.ID == id);
            if (todo == null)
            {
                return NotFound();
            }
            else 
            {
                ToDo = todo;
            }
            return Page();
        }
    }
}
