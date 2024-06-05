using UnityEngine;
using UnityEngine.AI;

namespace MOPC
{
    [RequireComponent(typeof(NavMeshAgent))]
    public sealed class EnemyAI : MonoBehaviour
    {
        [Header(HeaderTitles.Params)]
        [SerializeField] private int _damage;

        public Transform Player { get; set; }

        private NavMeshAgent _navMeshAgent;

        private void Awake()
        {
            InitComponentLinks();
        }

        // TODO при проблемах с оптимизацией подумать над уменьшением частоты обновления точки назначения.
        private void Update()
        {
            UpdateDestination();
        }

        private void OnCollisionEnter(Collision collision)
        {
            TryDealDamage(collision.gameObject);
        }

        private void InitComponentLinks()
        {
            _navMeshAgent = GetComponent<NavMeshAgent>();
        }

        private void UpdateDestination()
        {
            _navMeshAgent.destination = Player.position;
        }

        private void TryDealDamage(GameObject collisedObject)
        {
            if (collisedObject.TryGetComponent(out PlayerHealth playerHealth))
            {
                playerHealth.DealDamage(_damage);
            }
        }
    }
}
