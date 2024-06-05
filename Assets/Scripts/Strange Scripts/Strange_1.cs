using UnityEngine;

namespace MOPC
{
    [RequireComponent(typeof(AudioSource))]
    public sealed class Strange_1 : MonoBehaviour
    {
        private AudioSource _audioSource;

        private bool _go;

        private void Awake()
        {
            InitReferences();
        }

        private void TryPlaySound()
        {
            if (_go)
            {
                _audioSource.Play();
            }
        }

        public void GoPlease()
        {
            _go = true;
            InvokeRepeating(nameof(TryPlaySound), 0f, 9.5f);
        }

        public void NotGoPlease()
        {
            _go = false;
        }

        private void InitReferences()
        {
            _audioSource = GetComponent<AudioSource>();
        }
    }
}
