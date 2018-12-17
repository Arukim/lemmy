using Lemmy.App.Logic.Logging;
using Lemmy.App.Logic.Models;
using System.Numerics;

namespace Lemmy.App.Logic.Roles
{
    class Outsider : IRole
    {
        private static readonly ILogger logger = LogManager.GetLogger("Outsider");

        public ActionModel Act(RobotModel me, GameModel game)
        {
            var ballNormal = Vector3.Normalize(game.Ball.Velocity);

            var ourPathNormal = new Vector3(0, 0, -1);

            var targetNormal = Vector3.Normalize(ourPathNormal - ballNormal / 2);

            targetNormal *= (float)Constants.ROBOT_MAX_GROUND_SPEED;

            return new ActionModel
            {
                TargetVelocity = targetNormal * (float)Constants.ROBOT_MAX_GROUND_SPEED
            };
        }
    }
}
