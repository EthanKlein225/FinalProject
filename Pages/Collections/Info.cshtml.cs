using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using FinalProject.Models;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace FinalProject.Pages.Collections
{
    public class InfoModel : PageModel
    {
        private readonly ILogger<InfoModel> _logger;
        private readonly FinalProject.Models.Context _context;

        public InfoModel(FinalProject.Models.Context context, ILogger<InfoModel> logger)
        {
            _context = context;
            _logger = logger;
        }

        public Collection Collection { get; set; } = default!;

        [BindProperty]
        public int GameToDelete {get; set;}

        [BindProperty]
        [Display(Name = "Game")]
        public int GameToAdd {get; set;}
        public List<Game> AllGames {get; set;} = default!;
        public SelectList GamesDropDown {get; set;} = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Collection == null)
            {
                return NotFound();
            }

            var collection = await _context.Collection.Include(s => s.GameCollections!).ThenInclude(sc => sc.Game).FirstOrDefaultAsync(m => m.CollectionId == id);
            AllGames = await _context.Game.ToListAsync();
            GamesDropDown = new SelectList(AllGames, "GameId", "GameName");
            if (collection == null)
            {
                return NotFound();
            }
            else 
            {
                Collection = collection;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostDeleteCourseAsync(int? id)
        {
            _logger.LogWarning($"OnPost: CollectionId {id}, Remove game {GameToDelete}");
            if (id == null)
            {
                return NotFound();
            }

            var collection = await _context.Collection.Include(s => s.GameCollections!).ThenInclude(sc => sc.Game).FirstOrDefaultAsync(m => m.CollectionId == id);
            
            if (collection == null)
            {
                return NotFound();
            }
            else
            {
                Collection = collection;
            }

            GameCollection GameToRemove = _context.GameCollection.Find(GameToDelete, id.Value)!;
            if (GameToRemove != null)
            {
                _context.Remove(GameToRemove);
                _context.SaveChanges();
            }
            else
            {
                _logger.LogWarning("Collector doesn't own this game");
            }

            return RedirectToPage(new {id = id});
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            _logger.LogWarning($"OnPost: CollectionId {id}, add game {GameToAdd}");
            if (GameToAdd == 0)
            {
                ModelState.AddModelError("GameToAdd", "This field is a required field.");
                return Page();
            }
            if (id == null)
            {
                return NotFound();
            }

            var collection = await _context.Collection.Include(s => s.GameCollections!).ThenInclude(sc => sc.Game).FirstOrDefaultAsync(m => m.CollectionId == id);            
            AllGames = await _context.Game.ToListAsync();
            GamesDropDown = new SelectList(AllGames, "GameId", "GameName");

            if (collection == null)
            {
                return NotFound();
            }
            else
            {
                Collection = collection;
            }

            if (!_context.GameCollection.Any(sc => sc.GameId == GameToAdd && sc.CollectionId == id.Value))
            {
                GameCollection gameToAdd = new GameCollection {CollectionId = id.Value, GameId = GameToAdd};
                _context.Add(gameToAdd);
                _context.SaveChanges();
            }
            else
            {
                _logger.LogWarning("Collector already owns this game");
            }

            return RedirectToPage(new {id = id});
        }
    }
}