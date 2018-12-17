using Com.CodeGame.CodeBall2018.DevKit.CSharpCgdk.Model;
using System.Numerics;

namespace Lemmy.App.Logic.Models
{
    public class RobotModel
    {
        public int Id => Robot.id;
        public bool IsTeammate => Robot.is_teammate;
        public bool IsTouch => Robot.touch;

        public Robot Robot { get; private set; }
        public Vector3 Position { get; private set; }

        public RobotModel(Robot robot)
        {
            Robot = robot;
            Position = new Vector3((float)robot.x, (float)robot.y, (float)robot.z);
        }
    }
}
