using Com.CodeGame.CodeBall2018.DevKit.CSharpCgdk.Model;
using System.Collections.Generic;
using System.Linq;

namespace Lemmy.App.Logic.Models
{
    class GameModel
    {
        public Game Game { get; private set; }
        public Arena Arena { get; private set; }
        public BallModel Ball { get; private set; }
        public List<RobotModel> Robots { get; private set; }

        public GameModel(Game game, Arena arena)
        {
            Game = game;
            Arena = arena;
            Ball = new BallModel(game.ball);
            Robots = game.robots.Select(x => new RobotModel(x)).ToList();
        }
    }
}
