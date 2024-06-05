using UnityEngine;

namespace MOPC
{
    public sealed class Food : MonoBehaviour
    {
        [Header(HeaderTitles.Params)]
        [SerializeField] private float _speed = 1.0f;
        [SerializeField] private float _lifetime = 1.0f;
        [SerializeField] private int _damage = 1;
        [SerializeField] private FoodType _foodType;

        private float _timer;

        public PlayerHealth PlayerHealth { get; set; }

        private void Update()
        {
            UpdateTimer();
        }

        private void FixedUpdate()
        {
            UpdatePosition();
        }

        private void OnCollisionEnter(Collision collision)
        {
            HandleCollision(collision.gameObject);
        }

        private void UpdateTimer()
        {
            _timer += Time.deltaTime;
            if (_timer >= _lifetime)
            {
                Destroy();
            }
        }

        private void HandleCollision(GameObject collisedObject)
        {
            if (collisedObject.TryGetComponent(out EnemyHealth enemyHealth))
            {
                DamageEnemy(enemyHealth);
            }
            else
            {
                Destroy();
            }
        }

        private void UpdatePosition()
        {
            transform.Translate(_speed * Time.deltaTime * Vector3.forward);
        }

        private void DamageEnemy(EnemyHealth enemyHealth)
        {
            if (enemyHealth.RequiredFoodType == _foodType)
            {
                enemyHealth.DealDamage(_damage);
            }
            else
            {
                PlayerHealth.DealDamage(_damage);
            }
            Destroy();
        }

        private void Destroy()
        {
            Destroy(gameObject);
        }
    }
}
