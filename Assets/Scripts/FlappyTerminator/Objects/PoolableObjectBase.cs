using UnityEngine;

namespace Assets.Scripts.FlappyTerminator
{
    public abstract class PoolableObjectBase : MonoBehaviour
    {
        public abstract void Disable();
    }
}