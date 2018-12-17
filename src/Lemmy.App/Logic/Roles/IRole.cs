using Com.CodeGame.CodeBall2018.DevKit.CSharpCgdk.Model;
using Lemmy.App.Logic.Models;

namespace Lemmy.App.Logic.Roles
{
    interface IRole
    {
        ActionModel Act(RobotModel me, GameModel game);
    }
}
