using System;
using System.Numerics;

namespace Lemmy.Core.Logic
{
    public class Calculator
    {
        public static (double, double) SolveQuad(double a, double b, double c)
        {
            var desc = Math.Sqrt(b * b - 4 * a * c);

            return ((-b + desc) / (2 * a), (-b - desc) / (2 * a));
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

        public static double VectorIntersectPlane(Vector3 objPos, Vector3 objSpeed, Plane plane)
        {
            return -(Vector3.Dot(plane.Normal, objPos) + plane.D) / Vector3.Dot(plane.Normal, objSpeed);
        }
    }
}
