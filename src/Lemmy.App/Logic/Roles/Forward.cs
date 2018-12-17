using Lemmy.App.Logic.Geometry;
using Lemmy.App.Logic.Models;
using System;
using System.Numerics;

namespace Lemmy.App.Logic.Roles
{
    class Forward : IRole
    {
        public ActionModel Act(RobotModel me, GameModel game)
        {
            Console.WriteLine($"Me is in {me.Position}");

            if (!me.IsTouch)
            {
                return new ActionModel { TargetVelocity = new Vector3(0, -(float)Constants.MAX_ENTITY_SPEED, 0) };
            }
            // find path to the ball
            var path = Calculator.FindPath_ByGround(me.Position, game.Ball.Position, game.Ball.Velocity, Constants.GravityAcc);

            if (!path.HasValue)
            {
                Console.WriteLine("No path to target");
                return new ActionModel { };
            }

            var target = path.Value;

            target *= (float)Constants.ROBOT_MAX_GROUND_SPEED;

            return new ActionModel { TargetVelocity = target * (float)Constants.ROBOT_MAX_GROUND_SPEED };
        }
    }
}
