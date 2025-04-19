namespace Game_Zone.Controllers
{
    public class GamesController : Controller
    {
        public readonly ApplicationDbContext _context;
        public readonly IDeviceRepository deviceRepository;
        public readonly ICategoryRepository categoryRepository;
        public readonly IGameRepsitory gameRepsitory;

        public GamesController(IDeviceRepository DeviceRepository, ICategoryRepository CategoryRepository, IGameRepsitory GameRepsitory)
        {
            deviceRepository = DeviceRepository;
            categoryRepository = CategoryRepository;
            gameRepsitory = GameRepsitory;
        }



        public async Task<IActionResult> Index()
        {
            var games = gameRepsitory.GetAllGames();

            return View(games);
        }
        public IActionResult Details(int id)
        {
            var game = gameRepsitory.GetById(id);   
            if (game == null)
            {
                return NotFound();
            }
            return View(game);
        }

        [HttpGet]
        public IActionResult Create()
        {
            CreateVM vm = new CreateVM();

            vm.Categories = categoryRepository.GetAllCategories();
            vm.Devices = deviceRepository.GetAllDevices();

            return View("Create", vm);
        }
        [HttpPost]
        public async Task <IActionResult> Createview(CreateVM model)
        {

            if (!ModelState.IsValid)
            {
                model.Categories = categoryRepository.GetAllCategories();
                model.Devices = deviceRepository.GetAllDevices();
                return View("Create", model);
            }

            await gameRepsitory.Create(model);

            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Edit(int id) 
        {
            var game = gameRepsitory.GetById(id);
            if (game == null)
            {
                return NotFound();
            }
            EditVM vm = new EditVM()
            {
                Id = game.Id,
                Name = game.Name,
                Description = game.Description,
                CategoryId = game.CategoryId,
                Devices = deviceRepository.GetAllDevices(),
                SelectedDevices = game.Devices.Select(e => e.DeviceId).ToList(),
                Categories = categoryRepository.GetAllCategories(),
                CurrentCover=game.Cover,
                
            };
            return View(vm);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(EditVM model)
        {

            if (!ModelState.IsValid)
            {
                model.Categories = categoryRepository.GetAllCategories();
                model.Devices = deviceRepository.GetAllDevices();
                return View(model);
            }

            var game=await gameRepsitory.Udpate(model);

            if (game == null)
            {
                return BadRequest();
            }
            return RedirectToAction("Index");
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
          
            var isDeleted = gameRepsitory.Delete(id);
            
            return isDeleted ? Ok() : BadRequest();
        }


    }
}
