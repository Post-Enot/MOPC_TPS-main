using UnityEngine;

namespace MOPC
{
    public sealed class EnemyHealth : MonoBehaviour
    {
        [Header(HeaderTitles.ComponentReferences)]
        [SerializeField] private Transform _enemy;

        [Header(HeaderTitles.Prefabs)]
        [SerializeField] private GameObject _ascentionPrefab;

        [Header(HeaderTitles.Params)]
        [SerializeField] private int _healthPoints = 1;
        [SerializeField] private FoodType _requiredFoodType;

        public FoodType RequiredFoodType => _requiredFoodType;

        public void DealDamage(int damage)
        {
            _healthPoints -= damage;
            if (_healthPoints <= 0)
            {
                Destroy(gameObject);
                _ = Instantiate(_ascentionPrefab, _enemy.position, Quaternion.identity);
            }
        }
    }
}
