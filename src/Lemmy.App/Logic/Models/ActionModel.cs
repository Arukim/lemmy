using System;
using System.Numerics;

namespace Lemmy.App.Logic.Models
{
    class ActionModel
    {
        public Vector3 TargetVelocity { get; set; }
        public double JumpSpeed { get; set; }
        public bool UseNitro { get; set; }

        internal void Apply(Com.CodeGame.CodeBall2018.DevKit.CSharpCgdk.Model.Action action)
        {
            action.jump_speed = JumpSpeed;
            action.use_nitro = UseNitro;
            action.target_velocity_x = TargetVelocity.X;
            action.target_velocity_y = TargetVelocity.Y;
            action.target_velocity_z = TargetVelocity.Z;
        }

        public override string ToString()
        {
            return $"V:{TargetVelocity} J:{JumpSpeed} N:{UseNitro}";
        }
    }
}
