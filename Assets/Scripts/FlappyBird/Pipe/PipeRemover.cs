using UnityEngine;

namespace FlappyBird
{
    public class PipeRemover : MonoBehaviour
    {
        [SerializeField] private Pool<Pipe> _pool;

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.TryGetComponent(out Pipe pipe))
            {
                _pool.Return(pipe);
            }
        }
    }
}