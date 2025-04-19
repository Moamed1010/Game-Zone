
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Game_Zone.Repository
{
    public class GameRepsitory:IGameRepsitory
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _env;
        private readonly string _imagepath; 
        public GameRepsitory(ApplicationDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
            _imagepath = $"{_env.WebRootPath}{FileSettings.Imagespath}";
        }

        public IEnumerable<Game> GetAllGames()
        {
            return _context.Games
                .Include(g=>g.Category)
                .Include(g => g.Devices)
                .ThenInclude(g => g.Device)
                .AsNoTracking()
                .ToList();
        }
        public Game? GetById(int id)
        {
            return _context.Games
                 .Include(g => g.Category)
                 .Include(g => g.Devices)
                 .ThenInclude(g => g.Device)
                 .AsNoTracking()
                 .SingleOrDefault(g=>g.Id==id);
        }
        public async Task Create(CreateVM modle)
        {
           
          

            Game game = new Game()
            {
                Name = modle.Name,
                Description = modle.Description,
                CategoryId = modle.CategoryId,
                Cover = await savecover(modle.Cover),
                Devices = modle.SelectedDevices.Select(e => new GameDevice()
                {
                    DeviceId = e
                }).ToList()
            };

            _context.Games.Add(game);
            _context.SaveChanges();


        }
        public async Task<string> savecover(IFormFile cover)
        {
            var CoverName = $"{Guid.NewGuid()}{Path.GetExtension(cover.FileName)} ";
            var path = Path.Combine(_imagepath, CoverName);
            using var stream = File.Create(path);
            await cover.CopyToAsync(stream);
            return CoverName;
        }

        public async Task<Game?> Udpate(EditVM modle)
        {
            var game=_context.Games
                .Include(g=>g.Devices)
                .SingleOrDefault(g=>g.Id==modle.Id);
            var hasNewCover=modle.Cover is not null;
            var oldCover = game.Cover;

            if (game == null) { 
            return null;
            }
            game.Name = modle.Name;
            game.Description = modle.Description;
            game.CategoryId = modle.CategoryId;
            game.Devices = modle.SelectedDevices.Select(d => new GameDevice { DeviceId = d }).ToList();

            if (hasNewCover)
            {
                game.Cover = await savecover(modle.Cover!);
            }
            var effectedRows = _context.SaveChanges();
            if(effectedRows > 0)
            {
                if(hasNewCover)
                {
                    var Cover = Path.Combine(_imagepath, oldCover);
                    File.Delete(Cover);

                }
                return game;

            }
            else
            {
                if (hasNewCover)
                {
                    var Cover = Path.Combine(_imagepath, game.Cover);
                    File.Delete(Cover);
                }
                return null;
            }


        }

        public bool Delete(int id)
        {
            var isDeleted = false;
            var game=_context.Games.Find(id);
            if (game is null){
                return isDeleted;
            }
            _context.Remove(game);
            var affectedRows = _context.SaveChanges();
            if (affectedRows > 0)
            {
                isDeleted = true;
                var cover = Path.Combine(_imagepath, game.Cover);
                File.Delete(cover);
            }

            return isDeleted;
        }
    }
}
