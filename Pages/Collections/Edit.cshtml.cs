using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FinalProject.Models;

namespace FinalProject.Pages.Collections
{
    public class EditCollectionsModel : PageModel
    {
        private readonly ILogger<EditCollectionsModel> _logger;
        private readonly FinalProject.Models.Context _context;

        public EditCollectionsModel(FinalProject.Models.Context context, ILogger<EditCollectionsModel> logger)
        {
            _context = context;
            _logger = logger;
        }

        [BindProperty]
        public Collection Collection { get; set; } = default!;
        public List<Game> Games {get; set;} = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Game == null)
            {
                return NotFound();
            }

            var collection =  await _context.Collection.Include(s => s.GameCollections!).ThenInclude(sc => sc.Game).FirstOrDefaultAsync(m => m.CollectionId == id);
            Games = _context.Game.ToList();
            if (collection == null)
            {
                return NotFound();
            }
            Collection = collection;
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int[] selectedGames)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var collectionToUpdate = await _context.Collection.Include(s => s.GameCollections!).ThenInclude(sc => sc.Game).FirstOrDefaultAsync(m => m.CollectionId == Collection.CollectionId);
            if (collectionToUpdate != null) 
            {
                collectionToUpdate.Username = Collection.Username;
            }
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CollectionExists(Collection.CollectionId))
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

        private bool CollectionExists(int id)
        {
          return _context.Collection.Any(e => e.CollectionId == id);
        }
    }
}