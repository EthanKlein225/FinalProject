using System.ComponentModel.DataAnnotations;

namespace FinalProject.Models
{
    public class Game
    {
        public int GameId {get; set;}
        [Display(Name = "Game Name")]
        [Required]
        public string GameName {get; set;} = string.Empty;
        [Required]
        public string Genre {get; set;} = string.Empty;
        [Display(Name = "Release Date")]
        [Required]
        public DateTime ReleaseDate {get; set;}
        [Required]
        public string Console {get; set;} = string.Empty;
        [Required]
        public double Rating {get; set;}
        [Required]
        public List<GameCollection>? GameCollections {get; set;} = default!;
    }
}