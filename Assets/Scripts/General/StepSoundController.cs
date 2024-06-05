using UnityEngine;

namespace MOPC
{
    [SerializeField]
    public sealed class StepSoundController : MonoBehaviour
    {
        [Header(HeaderTitles.ComponentReferences)]
        [SerializeField] private PlayerController _playerController;

        [Header(HeaderTitles.Params)]
        [SerializeField] private float _stepSoundVolume = 0.5f;

        private AudioSource _audioSource;

        private void Awake()
        {
            InitReferences();
        }

        private void Update()
        {
            UpdateStepSoundVolume();
        }

        private void UpdateStepSoundVolume()
        {
            if (_playerController.IsMoving)
            {
                _audioSource.volume = _stepSoundVolume;
            }
            else
            {
                _audioSource.volume = 0.0f;
            }
        }

        private void InitReferences()
        {
            _audioSource = GetComponent<AudioSource>();
        }
    }
}
