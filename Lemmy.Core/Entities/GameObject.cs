using System.Numerics;

namespace Lemmy.Core.Entities
{
    public abstract class GameObject
    {
        public Vector3 Position { get; set; }
        public Vector3 Speed { get; set; }        
    }
}
