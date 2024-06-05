using UnityEngine;
using TMPro;

namespace MOPC
{
    [RequireComponent(typeof(TextMeshProUGUI))]
    public sealed class GameTime : MonoBehaviour
    {
        [Header(HeaderTitles.Params)]
        [SerializeField] private float _gameMinuteDuration = 0.5f;

        public int Hour { get; private set; } = 9;
        public int Minute { get; private set; }

        private TextMeshProUGUI _clockTextField;
        private float _timer;

        private void Awake()
        {
            InitReferences();
        }

        private void Start()
        {
            UpdateView();
        }

        private void Update()
        {
            UpdateTimer();
        }

        private void InitReferences()
        {
            _clockTextField = GetComponent<TextMeshProUGUI>();
        }

        private void UpdateTimer()
        {
            _timer += Time.deltaTime;
            if (_timer >= _gameMinuteDuration)
            {
                _timer = 0.0f;
                IncreaseGameTime();
                UpdateView();
            }
        }

        private void IncreaseGameTime()
        {
            Minute += 1;
            if (Minute >= 60)
            {
                Minute = 0;
                Hour += 1;
            }
        }

        private void UpdateView()
        {
            string formattedHour = Hour.ToString("00");
            string formattedMinute = Minute.ToString("00");
            _clockTextField.SetText($"{formattedHour}:{formattedMinute}");
        }
    }
}
