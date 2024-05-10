using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using FinalProject.Models;

namespace FinalProject.Pages.Collections
{
    public class IndexCollectionsModel : PageModel
    {
        private readonly FinalProject.Models.Context _context;

        public IndexCollectionsModel(FinalProject.Models.Context context)
        {
            _context = context;
        }

        public IList<Collection> Collection {get;set;} = default!;

        [BindProperty(SupportsGet = true)]
        public int PageNum {get; set;} = 1;
        public int PageSize {get; set;} = 10;

        [BindProperty(SupportsGet = true)]
        public string CurrentSort {get; set;}

        public async Task OnGetAsync()
        {
            if (_context.Collection != null)
            {
                var query = _context.Collection.Select(c => c);

                switch (CurrentSort){
                    case "user_asc":
                        query = query.OrderBy(c => c.Username);
                        break;
                    case "user_desc":
                        query = query.OrderByDescending(c => c.Username);
                        break;
                }
                Collection = await _context.Collection.Include(s => s.GameCollections!).ThenInclude(sc => sc.Game).ToListAsync();
                Collection = await query.Skip((PageNum-1)*PageSize).Take(PageSize).ToListAsync();
            }
        }
    }
}