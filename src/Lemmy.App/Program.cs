using System;
using Vector = System.Numerics.Vector3;

namespace Lemmy.App
{
    class Program
    {
        static void Main(string[] args)
        {
            var vec = new Vector { X = 1.0f, Y = 1.0f, Z = 1.0f };

            Console.WriteLine(vec.Length());
        }
    }
}
