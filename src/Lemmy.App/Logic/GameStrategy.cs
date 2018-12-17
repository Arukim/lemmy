using Com.CodeGame.CodeBall2018.DevKit.CSharpCgdk.Model;
using Lemmy.App.Logic.Models;
using System;
using Action = Com.CodeGame.CodeBall2018.DevKit.CSharpCgdk.Model.Action;

namespace Lemmy.App.Logic
{
    public static class GameStrategy
    {
        public static GameDescription gameDescription;
        private static Manager manager;

        internal static void Act(Robot me, Rules rules, Game game, Action action)
        {
            var meModel = new RobotModel(me);
            var gameModel = new GameModel(game);

            if (gameDescription == null)
                InitGame();

            if (me.id == gameDescription.FirstPlayerId)
                manager.EvaluteTurn(rules, gameModel);

            var act = manager.MakeTurn(meModel, gameModel, action);

            act.Apply(action);

            void InitGame()
            {
                gameDescription = new GameDescription
                {
                    Rules = rules,
                    FirstPlayerId = me.id
                };
                manager = new Manager();
            }
        }

        public class GameDescription
        {
            public Rules Rules;
            public int FirstPlayerId;
        }
    }
}
