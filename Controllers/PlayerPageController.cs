using IWebMVC.Data;
using Microsoft.AspNetCore.Mvc;

namespace IWebMVC.Controllers
{
    [Route("PlayerPage")]
    public class PlayerPageController : Controller
    {
        private readonly DatabaseContext _dbContext;

        public PlayerPageController(DatabaseContext dbContext) 
        {
            _dbContext = dbContext;
        }

        [Route("")]
        public IActionResult Index()
        {
            var players = _dbContext.Players.ToList();
            return View(players);
        }
    }
}
