using System;
using System.Numerics;

namespace Lemmy.App.Logic.Models
{
    class Constants
    {
        public const double ROBOT_ACCELERATION = 100.0;
        public const double ROBOT_MAX_GROUND_SPEED = 10.0;
        public const double MAX_ENTITY_SPEED = 100.0;
        public const double ROBOT_MAX_JUMP_SPEED = 15;
        public const double GRAVITY = 30.0;
        public const double BALL_RADIUS = 2.0;

        public static Vector3 GravityAcc => new Vector3(0, -(float)GRAVITY, 0);
        public static Vector3 GoalCenterEnemy(double depth) => new Vector3(0, 0, (float)depth / 2);
        public static Vector3 GoalCenterOurs(double depth) => new Vector3(0, 0, -(float)depth / 2);
    }
}
