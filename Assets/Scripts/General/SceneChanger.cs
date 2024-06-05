using UnityEngine;
using UnityEngine.SceneManagement;

namespace MOPC
{
    // TODO Переписать это чудо для всех типов переключения сцен.
    [RequireComponent(typeof(Animator))]
    public sealed class SceneChanger : MonoBehaviour
    {
        [Header(HeaderTitles.Params)]
        [SerializeField] private string _sceneName;

        [Header(HeaderTitles.AnimationParams)]
        [SerializeField] private string _paramNameFadeOut;

        public bool IsFadeAllow { get; set; }

        private Animator _animator;

        private void Awake()
        {
            InitReferences();
        }

        private void Update()
        {
            PressToFade();
        }

        public void Fade()
        {
            _animator.SetTrigger(_paramNameFadeOut);
        }

        public void PressToFade()
        {
            if (Input.GetKeyDown(KeyCode.E) && IsFadeAllow)
            {
                _animator.SetTrigger(_paramNameFadeOut);
            }
        }

        public void OnFadeComplete()
        {
            SceneManager.LoadScene(_sceneName);
        }

        private void InitReferences()
        {
            _animator = GetComponent<Animator>();
        }
    }
}
