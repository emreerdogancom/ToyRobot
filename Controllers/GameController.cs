using Microsoft.AspNetCore.Mvc;
using ToyRobot.Core.Abstract.Board;
using ToyRobot.Core.Concrete.Board;
using ToyRobot.Core.Game;
using ToyRobot.Models;

namespace ToyRobot.Controllers
{
    public class GameController : Controller
    {
        private readonly IBoard Board;
        private readonly RobotGame Game;

        public GameController()
        {
            Board = new Board(5, 5);
            Game = new RobotGame(Board);
        }

        public IActionResult Index()
        {
            return View(Board);
        }


        [HttpPost]

        public RobotResultModel Start([FromHeader] string input)
        {
            return Game.Start(input);
        }
    }
}
