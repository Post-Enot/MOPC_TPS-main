using UnityEngine;
using TMPro;

namespace MOPC
{
    [RequireComponent(typeof(AudioSource))]
    public sealed class FoodCaster : MonoBehaviour
    {
        [Header(HeaderTitles.ComponentReferences)]
        [SerializeField] private TextMeshProUGUI _appleCountTextField;
        [SerializeField] private TextMeshProUGUI _teaCountTextField;
        [SerializeField] private TextMeshProUGUI _saladCountTextField;
        [SerializeField] private PlayerHealth _playerHealth;

        [Header(HeaderTitles.Prefabs)]
        [SerializeField] private Food _applePrefab;
        [SerializeField] private Food _teaPrefab;
        [SerializeField] private Food _saladPrefab;

        [Header(HeaderTitles.Params)]
        [SerializeField] private int _appleMaxCount = 10;
        [SerializeField] private int _teaMaxCount = 10;
        [SerializeField] private int _saladMaxCount = 10;

        [SerializeField] private int _appleCount;
        [SerializeField] private int _teaCount;
        [SerializeField] private int _saladCount;

        [SerializeField] private float _delay = 1.0f;
        [SerializeField] private LayerMask _floorLayerMask;

        private AudioSource _audioSource;
        private FoodType _selectedFoodType;
        private float _timer;

        private void Awake()
        {
            InitReferences();
        }

        private void Start()
        {
            SetMaxFood();
            UpdateAllCountIndicators();
        }

        private void Update()
        {
            ChangeFoodsInHands();
            UpdateTimer();
            FoodCasting();
        }

        private void InitReferences()
        {
            _audioSource = GetComponent<AudioSource>();
        }

        public void AppleReload()
        {
            if (_appleCount < _appleMaxCount)
            {
                _appleCount += 1;
            }
            UpdateCountIndicator(_appleCountTextField, _appleCount);
        }

        public void TeaReload()
        {
            if (_teaCount < _teaMaxCount)
            {
                _teaCount += 1;
            }
            UpdateCountIndicator(_teaCountTextField, _teaCount);
        }

        public void SaladReload()
        {
            if (_saladCount < _saladMaxCount)
            {
                _saladCount += 1;
            }
            UpdateCountIndicator(_saladCountTextField, _saladCount);
        }

        private void SetMaxFood()
        {
            _appleCount = _appleMaxCount;
            _teaCount = _teaMaxCount;
            _saladCount = _saladMaxCount;
        }

        private void UpdateAllCountIndicators()
        {
            UpdateCountIndicator(_appleCountTextField, _appleCount);
            UpdateCountIndicator(_teaCountTextField, _teaCount);
            UpdateCountIndicator(_saladCountTextField, _saladCount);
        }

        private void UpdateCountIndicator(TextMeshProUGUI indicator, int count)
        {
            string countText = count.ToString();
            indicator.SetText(countText);
        }

        private void ChangeFoodsInHands()
        {
            if (Input.GetKeyDown(KeyCode.Z))
            {
                _selectedFoodType = FoodType.Apple;
            }
            else if (Input.GetKeyDown(KeyCode.X))
            {
                _selectedFoodType = FoodType.Tea;
            }
            else if (Input.GetKeyDown(KeyCode.C))
            {
                _selectedFoodType = FoodType.Salad;
            }
        }

        private void UpdateTimer()
        {
            _timer += Time.deltaTime;
        }

        private void FoodCasting()
        {
            if (Input.GetMouseButtonDown(0))
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                if (Physics.Raycast(ray, out RaycastHit hit, float.PositiveInfinity, _floorLayerMask))
                {
                    if (_timer > _delay)
                    {
                        switch (_selectedFoodType)
                        {
                            case FoodType.Apple:
                                if (_appleCount > 0)
                                {
                                    Temp(hit.point, _applePrefab);
                                    _appleCount -= 1;
                                    UpdateCountIndicator(_appleCountTextField, _appleCount);
                                }
                                break;

                            case FoodType.Tea:
                                if (_teaCount > 0)
                                {
                                    Temp(hit.point, _teaPrefab);
                                    _teaCount -= 1;
                                    UpdateCountIndicator(_teaCountTextField, _teaCount);
                                }
                                break;

                            case FoodType.Salad:
                                if (_saladCount > 0)
                                {
                                    Temp(hit.point, _saladPrefab);
                                    _saladCount -= 1;
                                    UpdateCountIndicator(_saladCountTextField, _saladCount);
                                }
                                break;
                        }
                    }
                }
            }
        }

        private void Temp(Vector3 point, Food foodPrefab)
        {
            Vector3 targetPosition = new Vector3(point.x, transform.position.y, point.z);
            Food food = Instantiate(foodPrefab, transform.position, Quaternion.identity);
            food.transform.LookAt(targetPosition);
            food.PlayerHealth = _playerHealth;
            _audioSource.Play();
            _timer = 0.0f;
        }
    }
}
