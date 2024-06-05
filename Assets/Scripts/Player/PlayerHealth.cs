using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace MOPC
{
    [RequireComponent(typeof(AudioSource))]
    public sealed class PlayerHealth : MonoBehaviour
    {
        [Header(HeaderTitles.ComponentReferences)]
        [SerializeField] private Image[] _heartIndicators;

        [Header(HeaderTitles.Params)]
        [SerializeField] private int _maxHealthPoints = 3;
        [SerializeField] private int _healthPoints;
        [SerializeField] private string _losingSceneName;

        [Header("Heart Icon Style:")]
        [SerializeField] private Sprite _heartIconFull;
        [SerializeField] private Sprite _heartIconEmpty;

        private AudioSource _audioSource;

        private void Awake()
        {
            InitReferences();
            SetFullHealth();
        }

        public void DealDamage(int damage)
        {
            _healthPoints -= damage;
            _audioSource.Play();
            UpdateHealthView();
            if (_healthPoints <= 0)
            {
                SceneManager.LoadScene(_losingSceneName);
            }
        }

        private void UpdateHealthView()
        {
            for (int i = 0; i < _heartIndicators.Length; i += 1)
            {
                Sprite heartIcon = _heartIconEmpty;
                if (i < _healthPoints)
                {
                    heartIcon = _heartIconFull;
                }
                _heartIndicators[i].sprite = heartIcon;
            }
        }

        private void SetFullHealth()
        {
            _healthPoints = _maxHealthPoints;
            UpdateHealthView();
        }

        private void InitReferences()
        {
            _audioSource = GetComponent<AudioSource>();
        }
    }
}
