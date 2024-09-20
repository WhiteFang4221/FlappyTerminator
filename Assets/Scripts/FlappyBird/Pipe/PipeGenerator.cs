using System.Collections;
using UnityEngine;

namespace FlappyBird
{
    [RequireComponent(typeof(Pool<>))]
    public class PipeGenerator : MonoBehaviour
    {
        [SerializeField] private float _lowerBound;
        [SerializeField] private float _upperBound;
        private Pool<Pipe> _pool;

        private WaitForSeconds _delay = new WaitForSeconds(1);

        private void Awake()
        {
            _pool = GetComponent<Pool<Pipe>>();
        }

        private void Start()
        {
            StartCoroutine(GeneratePipes());
        }

        public void DeletePipes()
        {
            _pool.Reset();
        }

        private IEnumerator GeneratePipes()
        {
            while (enabled)
            {
                Spawn();
                yield return _delay;
            }
        }

        private void Spawn()
        {
            float spawnPositionY = Random.Range(_upperBound, _lowerBound);
            Vector3 spawnpoint = new Vector3(transform.position.x, spawnPositionY, transform.position.z);
            var pipe = _pool.Get(spawnpoint);
        }
    }
}
