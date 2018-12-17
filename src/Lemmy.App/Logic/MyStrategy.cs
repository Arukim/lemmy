using Com.CodeGame.CodeBall2018.DevKit.CSharpCgdk.Model;
using Lemmy.App.Logic;

namespace Com.CodeGame.CodeBall2018.DevKit.CSharpCgdk
{
    public sealed class MyStrategy : IStrategy
    {
        public void Act(Robot me, Rules rules, Game game, Action action)
        {
            GameStrategy.Act(me, rules, game, action);
        }
    }
}



