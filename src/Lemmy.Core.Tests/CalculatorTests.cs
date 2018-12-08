using Lemmy.Core.Logic;
using NUnit.Framework;
using System.Numerics;

namespace Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void InterceptTime_given_same_pos_results_zero()
        {
            var pos = new Vector3 { X = 10 };
            var res = Calculator.InterceptTime(pos, Vector3.Zero, pos, 10);
            Assert.AreEqual(0.0, res);
        }

        [Test]
        public void InterceptTime_given_static_target_works()
        {
            var targetPos = new Vector3 { X = 100 };
            var res = Calculator.InterceptTime(targetPos, Vector3.Zero, Vector3.Zero, 25);
            Assert.AreEqual(4.0, res);
        }

        [Test]
        public void InterceptTime_given_moving_target_works()
        {
            var targetPos = new Vector3 { X = 10 };
            var targetSpeed = new Vector3 { X = 10 };
            var res = Calculator.InterceptTime(targetPos, targetSpeed, Vector3.Zero, 15);
            Assert.AreEqual(2.0, res);
        }
    }
}