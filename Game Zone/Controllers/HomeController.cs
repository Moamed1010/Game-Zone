using System.Diagnostics;
using Game_Zone.Models;
using Microsoft.AspNetCore.Mvc;

namespace Game_Zone.Controllers
{
    public class HomeController : Controller
    {
        private readonly IGameRepsitory _Gamerepo;

        public HomeController(IGameRepsitory Gamerepo)
        {
            _Gamerepo = Gamerepo;
        }

        public  async Task <IActionResult> Index()
        {
             var games =  _Gamerepo.GetAllGames();

             return View(games);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
