using UnityEngine;
using TMPro;

namespace MOPC
{
    [RequireComponent(typeof(TextMeshProUGUI))]
    public sealed class PlotScene0 : MonoBehaviour
    {
        private TextMeshProUGUI _textField;
        private bool _isTextOn;
        private bool _canTextBeOn;

        private void Awake()
        {
            _textField = GetComponent<TextMeshProUGUI>();
        }

        private void Start()
        {
            Invoke(nameof(Text), 2.5f);
            InvokeRepeating(nameof(Pulpit), 0f, 0.7f);
        }

        private void Update()
        {
            if(_isTextOn)
            {
                _textField.SetText("press EEEEEEEEEE to wake up");
            }
            else
            {
                _textField.SetText(string.Empty);
            }
        }

        private void Text()
        {
            _canTextBeOn = true;
        }

        private void Pulpit()
        {
            if (_canTextBeOn)
            {
                _isTextOn = !_isTextOn;
            }
        }
    }
}
