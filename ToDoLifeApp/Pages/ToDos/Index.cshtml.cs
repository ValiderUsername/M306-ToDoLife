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
    public class IndexModel : PageModel
    {
        private readonly ToDoLifeApp.Data.ApplicationDbContext _context;

        public IndexModel(ToDoLifeApp.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<ToDo> ToDo { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.ToDo != null)
            {
                ToDo = await _context.ToDo.ToListAsync();
            }
        }
    }
}
