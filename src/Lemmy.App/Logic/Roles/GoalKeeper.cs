using Com.CodeGame.CodeBall2018.DevKit.CSharpCgdk.Model;
using Lemmy.App.Logic.Models;

namespace Lemmy.App.Logic.Roles
{
    class GoalKeeper : IRole
    {
        public ActionModel Act(RobotModel me, GameModel game)
        {
            return new ActionModel { };
        }
    }
}
