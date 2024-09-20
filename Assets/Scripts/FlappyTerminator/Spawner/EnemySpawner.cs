using System.Collections;
using UnityEngine;

namespace Assets.Scripts.FlappyTerminator
{
    public class EnemySpawner : Spawner<Enemy>
    {
        [SerializeField] private BulletSpawner _bulletSpawner;
        [SerializeField] private ScoreCounter _scoreCounter;
        [SerializeField] private float _lowerBound;
        [SerializeField] private float _upperBound;
        
        private Pool<Enemy> _pool;
        private WaitForSeconds _delay = new WaitForSeconds(1.5f);

        private void Awake()
        {
            _pool = GetComponent<Pool<Enemy>>();
        }

        private void Start()
        {
            StartCoroutine(SpawnEnemy());
        }

        private IEnumerator SpawnEnemy()
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
            Enemy enemy = GetObject(spawnpoint);
            enemy.InitBulletSpawner(_bulletSpawner);
            enemy.Died += _scoreCounter.Add;
        }

        protected override void DestroyObject(Enemy enemy)
        {
            base.DestroyObject(enemy);
            enemy.Died -= _scoreCounter.Add;
        }
    }
}