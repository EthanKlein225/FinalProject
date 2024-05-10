using System.ComponentModel.DataAnnotations;

namespace FinalProject.Models
{
    public class Collection
    {
        public int CollectionId {get; set;}
        [Required]
        public string Username {get; set;} = string.Empty;
        public List<GameCollection> GameCollections {get; set;} = default!;
    }

    public class GameCollection
    {
        public int CollectionId {get; set;}
        public int GameId {get; set;}    
        public Game Game {get; set;} = default!; 
        public Collection Collection {get; set;} = default!;   
    }
}