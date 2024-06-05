using System;
using UnityEngine;

namespace MOPC
{
    public sealed class EnemySpawner : MonoBehaviour
    {
        [Header(HeaderTitles.Prefabs)]
        [SerializeField] private EnemyAI _appleWanterPrefab;
        [SerializeField] private EnemyAI _teaWanterPrefab;
        [SerializeField] private EnemyAI _saladWanterPrefab;

        [Header(HeaderTitles.ComponentReferences)]
        [SerializeField] private Transform _player;

        [Header(HeaderTitles.Params)]
        [SerializeField] private float _minDelay;
        [SerializeField] private float _maxDelay;

        private float _timer;
        private float _delay;

        private void Start()
        {
            SetRandomDelay();
        }

        private void Update()
        {
            UpdateTimer();
        }

        private void OnValidate()
        {
            ValidateDelayRange();
        }

        private void ValidateDelayRange()
        {
            if (_minDelay > _maxDelay)
            {
                _minDelay = _maxDelay;
            }
        }

        private void SpawnEnemy()
        {
            int randomIndex = UnityEngine.Random.Range(0, 3);
            EnemyAI enemyPrefab = randomIndex switch
            {
                0 => _appleWanterPrefab,
                1 => _teaWanterPrefab,
                2 => _saladWanterPrefab,
                _ => throw new IndexOutOfRangeException()
            };
            EnemyAI enemy = Instantiate(enemyPrefab, transform.position, Quaternion.identity);
            enemy.Player = _player;
        }

        private void UpdateTimer()
        {
            _timer += Time.deltaTime;
            if (_timer > _delay)
            {
                _timer = 0.0f;
                SpawnEnemy();
                SetRandomDelay();
            }
        }

        private void SetRandomDelay()
        {
            _delay = UnityEngine.Random.Range(_minDelay, _maxDelay);
        }
    }
}
