using Com.CodeGame.CodeBall2018.DevKit.CSharpCgdk.Model;
using Lemmy.App.Logic.Models;
using Lemmy.App.Logic.Roles;
using System.Collections.Generic;
using System.Linq;
using Action = Com.CodeGame.CodeBall2018.DevKit.CSharpCgdk.Model.Action;

namespace Lemmy.App.Logic
{
    class Manager
    {
        private List<(int id, IRole role)> roles = new List<(int, IRole)>();

        internal void EvaluteTurn(Rules rules, GameModel game)
        {
            roles = game.Robots
                          .Where(x => x.IsTeammate)
                          .Select((x, it) =>
                          {
                              IRole role;
                              if (x.Id % 2 == 0)
                              {
                                  role = new Forward();
                              }
                              else
                              {
                                  role = new GoalKeeper();
                              }
                              return (x.Id, role);
                          }).ToList();
        }

        internal ActionModel MakeTurn(RobotModel me, GameModel game, Action action)
        {
            var role = roles.First(x => x.id == me.Id).role;
            return role.Act(me, game);
        }
    }
}
