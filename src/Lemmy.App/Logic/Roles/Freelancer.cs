using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;
using Lemmy.App.Logic.Geometry;
using Lemmy.App.Logic.Logging;
using Lemmy.App.Logic.Models;

namespace Lemmy.App.Logic.Roles
{
    class Freelancer : IRole
    {
        private static ILogger logger = LogManager.GetLogger("Freelancer");

        public ActionModel Act(RobotModel me, GameModel game)
        {
            if (!me.IsTouch)
            {
                return new ActionModel { TargetVelocity = new Vector3(0, -(float)Constants.MAX_ENTITY_SPEED, 0) };
            }

            // find drop point of the ball
            var dropPoint = Calculator.Find_DropPoint(game.Ball.Position, game.Ball.Velocity, Constants.GravityAcc);
            var ourGoal = Constants.GoalCenterOurs(game.Arena.depth);

            var midpoint = Calculator.Find_Midpoint(dropPoint, ourGoal);

            var targetNormal = Vector3.Normalize(midpoint - me.Position);

            targetNormal *= (float)Constants.ROBOT_MAX_GROUND_SPEED;

            return new ActionModel
            {
                TargetVelocity = targetNormal * (float)Constants.ROBOT_MAX_GROUND_SPEED
            };
        }
    }
}
