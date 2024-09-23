using System;

namespace Assets.Scripts.FlappyTerminator
{
    public class PoolableObject<T> : PoolableObjectBase where T : PoolableObject<T>
    {
        public event Action<T> Disabled;

        public override void Disable()
        {
            Disabled.Invoke((T)this);
        }
    }
}