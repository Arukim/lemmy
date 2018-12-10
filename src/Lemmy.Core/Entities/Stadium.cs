using Lemmy.Core.Enums;
using Lemmy.Core.Logic;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;

namespace Lemmy.Core.Entities
{
    public class Stadium
    {
        public IReadOnlyCollection<Plane> Planes { get; set; }

        public Stadium(int width, int depth, int height)
        {
            var edge_0_0_0 = Vector3.Zero;
            var edge_0_0_1 = new Vector3(0, 0, height);
            var edge_1_0_0 = new Vector3(width, 0, 0);
            var edge_0_1_1 = new Vector3(0, depth, height);
            var edge_1_1_0 = new Vector3(width, depth, 0);
            var edge_1_1_1 = new Vector3(width, depth, height);

            Planes = new List<Plane>
            {
                // bottom
                Plane.CreateFromVertices(edge_0_0_0, edge_1_0_0, edge_1_1_0),
                // front
                Plane.CreateFromVertices(edge_0_0_0, edge_1_0_0, edge_0_0_1),
                // left
                Plane.CreateFromVertices(edge_0_0_0, edge_0_0_1, edge_0_1_1),
                // back
                Plane.CreateFromVertices(edge_0_1_1,edge_1_1_0, edge_1_1_1),
                // right
                Plane.CreateFromVertices(edge_1_0_0, edge_1_1_0, edge_1_1_1),
                // top
                Plane.CreateFromVertices(edge_0_0_1, edge_0_1_1, edge_1_1_1)
            };
        }

        /// <summary>
        /// Find out which wall would be hit by the ball
        /// </summary>
        /// <param name="ball"></param>
        /// <returns>Tuple of wallType and collision time</returns>
        public (WallType Type, float Time) FindWallHit(Ball ball)
        {
            return Planes.Select((x, i) => (Type: (WallType)i, Time: Calculator.VectorIntersectPlane(ball.Position, ball.Speed, x)))
                .Where(x => x.Time > 0)
                .OrderBy(x => x.Time)
                .First();
        }
    }
}
