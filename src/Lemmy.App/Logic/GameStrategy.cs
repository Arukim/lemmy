using Com.CodeGame.CodeBall2018.DevKit.CSharpCgdk.Model;
using Lemmy.App.Logic.Logging;
using Lemmy.App.Logic.Models;
using Action = Com.CodeGame.CodeBall2018.DevKit.CSharpCgdk.Model.Action;

namespace Lemmy.App.Logic
{
    public static class GameStrategy
    {
        public static GameDescription gameDescription;
        private static Manager manager;
        private static ILogger logger = LogManager.GetLogger("GameStrategy");

        internal static void Act(Robot me, Rules rules, Game game, Action action)
        {
            var meModel = new RobotModel(me);
            var gameModel = new GameModel(game, rules.arena);

            if (gameDescription == null || game.current_tick < gameDescription.CurrentTurn)
                InitGame();

            if (game.current_tick > gameDescription.CurrentTurn)
            {
                logger.Log("Call manager");
                manager.EvaluteTurn(rules, gameModel);
                gameDescription.CurrentTurn++;
            }

            var act = manager.MakeTurn(meModel, gameModel, action);

            logger.Log($"Making turn {act}");

            act.Apply(action);

            void InitGame()
            {
                gameDescription = new GameDescription
                {
                    Rules = rules,
                    CurrentTurn = -1
                };
                manager = new Manager();
            }
        }

        public class GameDescription
        {
            public Rules Rules;
            public int CurrentTurn;
        }
    }
}
