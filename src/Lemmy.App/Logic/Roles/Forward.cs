using Lemmy.App.Logic.Geometry;
using Lemmy.App.Logic.Logging;
using Lemmy.App.Logic.Models;
using System.Numerics;

namespace Lemmy.App.Logic.Roles
{
    class Forward : IRole
    {
        private static ILogger logger = LogManager.GetLogger("Forward");

        public ActionModel Act(RobotModel me, GameModel game)
        {
            bool isJumping = false;
            logger.Log($"Me is in {me.Position}");

            if (!me.IsTouch)
            {
                return new ActionModel { TargetVelocity = new Vector3(0, -(float)Constants.MAX_ENTITY_SPEED, 0) };
            }
            // find drop point of the ball
            var dropPoint = Calculator.Find_DropPoint(game.Ball.Position, game.Ball.Velocity, Constants.GravityAcc);

            var hitPoint = Calculator.Find_Hitpoint(game.Ball.Position, Constants.BALL_RADIUS, Constants.GoalCenterEnemy(game.Arena.depth));

            var accT = Calculator.Find_GroundReachTime(hitPoint, me.Position, me.Velocity, Constants.ROBOT_MAX_GROUND_SPEED, Constants.ROBOT_ACCELERATION);

            // find vector
            var targetNormal = Vector3.Normalize(hitPoint - me.Position);

            // if we would reach ball on next turn - make a jump
            if (accT < 0)
            {
                targetNormal.Y = (float)(1 - accT);
                targetNormal = Vector3.Normalize(targetNormal);
                isJumping = true;
            }

            targetNormal *= (float)Constants.ROBOT_MAX_GROUND_SPEED;

            return new ActionModel
            {
                TargetVelocity = targetNormal * (float)Constants.ROBOT_MAX_GROUND_SPEED,
                JumpSpeed = isJumping ? Constants.MAX_ENTITY_SPEED : 0
            };
        }
    }
}
