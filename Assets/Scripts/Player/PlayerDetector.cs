using UnityEngine;
using UnityEngine.Events;

namespace MOPC
{
    public sealed class PlayerDetector : MonoBehaviour
    {
        [SerializeField] private UnityEvent _onPlayerEnter;
        [SerializeField] private UnityEvent _onPlayerExit;

        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out PlayerController _))
            {
                _onPlayerEnter.Invoke();
            }
        }
        private void OnTriggerExit(Collider other)
        {
            if (other.TryGetComponent(out PlayerController _))
            {
                _onPlayerExit.Invoke();
            }
        }
    }
}
