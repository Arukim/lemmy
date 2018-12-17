using Com.CodeGame.CodeBall2018.DevKit.CSharpCgdk.Model;
using Lemmy.App.Logic.Geometry;
using Lemmy.App.Logic.Logging;
using Lemmy.App.Logic.Models;
using Lemmy.App.Logic.Roles;
using System.Collections.Generic;
using System.Linq;
using Action = Com.CodeGame.CodeBall2018.DevKit.CSharpCgdk.Model.Action;

namespace Lemmy.App.Logic
{
    class Manager
    {
        private static readonly ILogger logger = LogManager.GetLogger("Manager");

        private List<(int id, IRole role)> roles = new List<(int, IRole)>();

        internal void EvaluteTurn(Rules rules, GameModel game)
        {
            roles.Clear();

            var freeRobots = game.Robots
                          .Where(x => x.IsTeammate)
                          .ToList();

            var outsiders = freeRobots.Where(x => x.Position.Z >= game.Ball.Position.Z).ToList();

            foreach (var r in outsiders)
                AssignRole(r, new Outsider());

            var dropPoint = Calculator.Find_DropPoint(game.Ball.Position, game.Ball.Velocity, Constants.GravityAcc);

            var forward = freeRobots
                .OrderBy(x => Calculator.Find_GroundReachTime(dropPoint, x.Position, x.Velocity, Constants.ROBOT_MAX_GROUND_SPEED, Constants.ROBOT_ACCELERATION))
                .FirstOrDefault();

            if (forward != null)
                AssignRole(forward, new Forward());

            foreach (var r in freeRobots.ToList())
                AssignRole(r, new Freelancer());

            void AssignRole(RobotModel robot, IRole role)
            {
                roles.Add((robot.Id, role));
                freeRobots.Remove(robot);
            }
        }

        internal ActionModel MakeTurn(RobotModel me, GameModel game, Action action)
        {
            var role = roles.First(x => x.id == me.Id).role;
            return role.Act(me, game);
        }
    }
}
