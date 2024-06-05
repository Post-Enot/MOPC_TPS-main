using UnityEngine;

namespace MOPC
{
    [RequireComponent(typeof(AudioSource))]
    public sealed class EnemyAscention : MonoBehaviour
    {
        [SerializeField] private float _timeToDisappear = 1.0f;

        private AudioSource _audioSource;
        private float _timer;

        private void Awake()
        {
            _audioSource = GetComponent<AudioSource>();
            _audioSource.Play();
        }

        private void Update()
        {
            UpdateTimer();
        }

        private void UpdateTimer()
        {
            _timer += Time.deltaTime;
            if (_timer >= _timeToDisappear)
            {
                Destroy(gameObject);
            }
        }
    }
}
