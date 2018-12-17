using System;
using System.Numerics;

namespace Lemmy.App.Logic.Geometry
{
    class Calculator
    {
        public static (double rootA, double rootB) SolveQuad(double a, double b, double c)
        {
            var desc = Math.Sqrt(b * b - 4 * a * c);

            return ((-b - desc) / (2 * a), (-b + desc) / (2 * a));
        }

        public static double InterceptTime(Vector3 targetPos, Vector3 targetSpeed, Vector3 catcherPos, double catcherSpeed)
        {
            var dPos = targetPos - catcherPos;

            var a = Vector3.Dot(targetSpeed, targetSpeed) - catcherSpeed * catcherSpeed;

            var b = 2 * Vector3.Dot(dPos, targetSpeed);

            var c = Vector3.Dot(dPos, dPos);

            var (q1, q2) = SolveQuad(a, b, c);

            return Math.Max(q1, q2);
        }

        public static float VectorIntersectPlane(Vector3 objPos, Vector3 objSpeed, Plane plane)
        {
            return -(Vector3.Dot(plane.Normal, objPos) + plane.D) / Vector3.Dot(plane.Normal, objSpeed);
        }

        public static Vector3? FindPath_ByGround(Vector3 catcherPos, Vector3 targetPos, Vector3 targetVelocity, Vector3 targetAcceleration)
        {
            // find ball-drop-time
            double a = targetAcceleration.Y / 2, b = targetVelocity.Y, c = targetPos.Y;

            var (q1, q2) = SolveQuad(a, b, c);

            var tDown = Math.Max(q1, q2);

            if (tDown < 0)
                return null;

            // find ball-drop-pos
            var dropPos = targetPos + targetVelocity * (float)tDown;

            // find vector
            var targetVector = dropPos - catcherPos;
            
            return Vector3.Normalize(targetVector);       
        }
    }
}
