using UnityEngine;
using UnityEngine.Events;

namespace MOPC
{
    [RequireComponent(typeof(AudioSource))]
    public sealed class Strange_0 : MonoBehaviour
    {
        [SerializeField] private UnityEvent _onPlayerEnter;

        private AudioSource _audioSource;
        private bool _isDetected;


        private void Awake()
        {
            InitReferences();
        }

        private void Update()
        {
            if (!_audioSource.isPlaying && !_isDetected)
            {
                _isDetected = true;
                _onPlayerEnter.Invoke();
            }
        }

        private void InitReferences()
        {
            _audioSource = GetComponent<AudioSource>();
        }
    }
}
