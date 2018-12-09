using Lemmy.Core.Entities;
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
            double dX = targetPos.X - catcherPos.X, dY = targetPos.Y - catcherPos.Y, dZ = targetPos.Z - catcherPos.Z;

            var a = targetSpeed.X * targetSpeed.X + targetSpeed.Y * targetSpeed.Y + targetSpeed.Z * targetSpeed.Z - catcherSpeed * catcherSpeed;

            var b = 2 * (dX * targetSpeed.X + dY * targetSpeed.Y + dZ *targetSpeed.Z);

            var c = dX * dX + dY * dY + dZ * dZ;

            var (q1,q2) = SolveQuad(a, b, c);

            return Math.Max(q1, q2);
        }

        public static double VectorIntersectPlane(Vector3 objPos, Vector3 objSpeed, Plane plane)
        {
            return -(Vector3.Dot(plane.Normal, objPos) + plane.D) / Vector3.Dot(plane.Normal, objSpeed); 
        }
    }
}
