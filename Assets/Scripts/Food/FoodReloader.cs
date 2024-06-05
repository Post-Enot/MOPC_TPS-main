using UnityEngine;
using UnityEngine.Events;

namespace MOPC
{
    public sealed class FoodReloader : MonoBehaviour
    {
        [SerializeField] private UnityEvent _onPlayerReloaded;
        [SerializeField] private float _delay = 1.0f;

        private bool _isPlayerInTrigger;
        private float _timer;

        private void Update()
        {
            HandleReloading();
            UpdateTimer();
        }

        private void HandleReloading()
        {
            if (Input.GetKeyDown(KeyCode.E) && _isPlayerInTrigger && (_timer > _delay))
            {
                _onPlayerReloaded.Invoke();
                _timer = 0.0f;
            }
        }

        private void UpdateTimer()
        {
            _timer += Time.deltaTime;
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out PlayerController _))
            {
                _isPlayerInTrigger = true;
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.TryGetComponent(out PlayerController _))
            {
                _isPlayerInTrigger = false;
            }
        }
    }
}
