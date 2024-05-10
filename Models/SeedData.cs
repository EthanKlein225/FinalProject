using Microsoft.EntityFrameworkCore;

namespace FinalProject.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new Context(serviceProvider.GetRequiredService<DbContextOptions<Context>>()))
            {
                if (context.Game.Any())
                {
                    return;
                }

                List<Game> games = new List<Game> {
                    new Game {GameName="Sonic The Hedgehog", Genre="Platformer", ReleaseDate=DateTime.Parse("1991-06-23"), Console="SEGA Genesis", Rating=8.0},
                    new Game {GameName="Super Mario Bros.", Genre="Platformer", ReleaseDate=DateTime.Parse("1985-09-13"), Console="NES", Rating=9.0},
                    new Game {GameName="The Legend of Zelda: Twilight Princess", Genre="RPG", ReleaseDate=DateTime.Parse("2006-11-19"), Console="Nintendo Wii/Gamecube", Rating=9.5},
                    new Game {GameName="Donkey Kong Country Returns", Genre="Platformer", ReleaseDate=DateTime.Parse("2010-11-21"), Console="Nintendo Wii", Rating=9.0},
                    new Game {GameName="Call of Duty 4", Genre="FPS", ReleaseDate=DateTime.Parse("2007-11-05"), Console="PS3/Xbox 360/PC", Rating=9.4},
                    new Game {GameName="Final Fantasy XII", Genre="RPG", ReleaseDate=DateTime.Parse("2006-03-16"), Console="PS2", Rating=9.5},
                    new Game {GameName="Dragon Quest III", Genre="RPG", ReleaseDate=DateTime.Parse("1988-02-10"), Console="NES", Rating=10.0},
                    new Game {GameName="Dynasty Warriors 9", Genre="Hack and Slash", ReleaseDate=DateTime.Parse("2018-02-08"), Console="PS4/Xbox One/PC", Rating=5.8},
                    new Game {GameName="League of Legends", Genre="MOBA", ReleaseDate=DateTime.Parse("2009-10-27"), Console="PC", Rating=9.2},
                    new Game {GameName="Counter Strike 2", Genre="FPS", ReleaseDate=DateTime.Parse("2023-09-27"), Console="PC", Rating=7.1},
                    new Game {GameName="Northgard", Genre="RTS", ReleaseDate=DateTime.Parse("2017-02-22"), Console="PC", Rating=7.7},
                    new Game {GameName="Spyro: Reignited Trilogy", Genre="Platformer", ReleaseDate=DateTime.Parse("2018-11-13"), Console="PS4/Xbox One", Rating=8.5},
                    new Game {GameName="Mario Party 6", Genre="Party", ReleaseDate=DateTime.Parse("2004-12-06"), Console="Gamecube", Rating=7.0},
                    new Game {GameName="WWE 2K24", Genre="Sports", ReleaseDate=DateTime.Parse("2024-03-08"), Console="PS5/PS4/Xbox Series X/Xbox One/PC", Rating=8.0},
                    new Game {GameName="Persona 3 Reload", Genre="RPG", ReleaseDate=DateTime.Parse("2024-02-02"), Console="PS5/PS4/Xbox Series X/Xbox One/PC", Rating=9.0},
                    new Game {GameName="Super Mario RPG", Genre="RPG", ReleaseDate=DateTime.Parse("2023-11-17"), Console="Nintendo Switch", Rating=8.0},
                    new Game {GameName="Jackbox Party Pack 3", Genre="Party", ReleaseDate=DateTime.Parse("2016-10-18"), Console="PS4/Xbox One/PC", Rating=8.0},
                    new Game {GameName="Sonic and the Secret Rings", Genre="Platformer", ReleaseDate=DateTime.Parse("2007-02-20"), Console="Nintendo Wii", Rating=6.9},
                    new Game {GameName="Pokemon SoulSilver", Genre="RPG", ReleaseDate=DateTime.Parse("2009-09-12"), Console="Nintendo DS", Rating=8.5},
                    new Game {GameName="Fortnite", Genre="Battle Royale", ReleaseDate=DateTime.Parse("2017-07-21"), Console="PS4/Xbox One/PC", Rating=9.6},
                    new Game {GameName="Puyo Puyo Tetris 2", Genre="Puzzle", ReleaseDate=DateTime.Parse("2020-12-08"), Console="PS5/PS4/Xbox Series X/Xbox One/Nintendo Switch", Rating=7.7},
                    new Game {GameName="Golden Axe", Genre="Beat Em' Up", ReleaseDate=DateTime.Parse("1989-12-22"), Console="SEGA Genesis", Rating=4.0},
                    new Game {GameName="Space Channel 5", Genre="Rhythm", ReleaseDate=DateTime.Parse("1999-12-16"), Console="SEGA Dreamcast", Rating=9.2},
                    new Game {GameName="Theatrhythm: Final Bar Line", Genre="Rhythm", ReleaseDate=DateTime.Parse("2023-02-16"), Console="PS4/Nintendo Switch", Rating=9.0},
                    new Game {GameName="Sonic Adventure 2 Battle", Genre="Platformer", ReleaseDate=DateTime.Parse("2001-12-20"), Console="Gamecube", Rating=9.4}
                    
                };
                context.AddRange(games);

                List<Collection> collections = new List<Collection> {
                    new Collection {Username = "Ethanklein225"},
                    new Collection {Username = "Sonic_Boi69"},
                    new Collection {Username = "Awesomedudeman890"},
                    new Collection {Username = "SmashBrosBoi"},
                    new Collection {Username = "EZE1230"},
                    new Collection {Username = "Ezerocks11"},
                    new Collection {Username = "SparkleDust123"},
                    new Collection {Username = "QuantumQuasar"},
                    new Collection {Username = "MysticWhisperer"},
                    new Collection {Username = "PixelPioneer"},
                    new Collection {Username = "EchoEchoEcho"},
                    new Collection {Username = "MidnightMarauder"},
                    new Collection {Username = "VelvetVortex"},
                    new Collection {Username = "SolarFlare87"},
                    new Collection {Username = "FrostyFalcon"},
                    new Collection {Username = "CosmicCrafter"},
                    new Collection {Username = "ShadowStormer"},
                    new Collection {Username = "WhisperingWillow"},
                    new Collection {Username = "ElectricEmber"},
                    new Collection {Username = "LunarLullaby"},
                    new Collection {Username = "NeonNebula"},
                    new Collection {Username = "SereneSpectre"},
                    new Collection {Username = "EnigmaEclipse"},
                    new Collection {Username = "RadiantRaven"},
                    new Collection {Username = "StarlightStalker"},
                    new Collection {Username = "DreamingDragonfly"}
                };
                context.AddRange(collections);

                List<GameCollection> owned = new List<GameCollection> {
                    new GameCollection {CollectionId = 1, GameId = 1},
                    new GameCollection {CollectionId = 1, GameId = 9},
                    new GameCollection {CollectionId = 2, GameId = 17},
                    new GameCollection {CollectionId = 3, GameId = 3},
                    new GameCollection {CollectionId = 4, GameId = 22},
                    new GameCollection {CollectionId = 4, GameId = 6},
                    new GameCollection {CollectionId = 7, GameId = 12},
                    new GameCollection {CollectionId = 9, GameId= 20},
                    new GameCollection {CollectionId = 10, GameId = 4},
                    new GameCollection {CollectionId = 12, GameId = 8},
                    new GameCollection {CollectionId = 14, GameId = 19},
                    new GameCollection {CollectionId = 15, GameId = 5},
                    new GameCollection {CollectionId = 17, GameId = 14},
                    new GameCollection {CollectionId = 18, GameId = 23},
                    new GameCollection {CollectionId = 19, GameId = 7},
                    new GameCollection {CollectionId = 21, GameId = 2},
                    new GameCollection {CollectionId = 23, GameId = 11},
                    new GameCollection {CollectionId = 25, GameId = 18},
                    new GameCollection {CollectionId = 25, GameId = 25},
                    new GameCollection {CollectionId = 25, GameId = 10},
                };
                context.AddRange(owned);

                context.SaveChanges();
            }
        }
    }
}