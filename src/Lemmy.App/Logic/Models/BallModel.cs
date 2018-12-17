using Com.CodeGame.CodeBall2018.DevKit.CSharpCgdk.Model;
using System.Numerics;

namespace Lemmy.App.Logic.Models
{
    class BallModel
    {
        public Ball Ball { get; private set; }

        public Vector3 Position { get; private set; }
        public Vector3 Velocity { get; private set; }
        public double Radius => Ball.radius;

        public BallModel(Ball ball)
        {
            Ball = ball;
            Position = new Vector3((float)ball.x, (float)ball.y, (float)ball.z);
            Velocity = new Vector3((float)ball.velocity_x, (float)ball.velocity_y, (float)ball.velocity_z);
        }
    }
}
