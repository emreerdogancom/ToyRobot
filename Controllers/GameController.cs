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

        public GameController()
        {
            Board = new Board(5, 5);
        }

        public IActionResult Index()
        {
            return View(Board);
        }


        [HttpPost]

        public RobotResultModel Start([FromHeader] string input)
        {
            RobotGame Game = new RobotGame(Board);
            return Game.Start(input);
        }
    }
}
