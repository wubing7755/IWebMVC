using IWebMVC.Data;
using Microsoft.AspNetCore.Mvc;

namespace IWebMVC.Controllers
{
    public class PlayerPageController : Controller
    {
        private readonly DatabaseContext _dbContext;
        public PlayerPageController(DatabaseContext dbContext) 
        {
            _dbContext = dbContext;
        }

        [Route("PlayerPage")]
        public IActionResult Index()
        {
            var players = _dbContext.Players;
            return View(players);
        }
    }
}
