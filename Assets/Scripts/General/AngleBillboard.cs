using UnityEngine;

namespace MOPC
{
    public sealed class AngleBillboard : MonoBehaviour
    {
        [Header(HeaderTitles.ComponentReferences)]
        [SerializeField] private Animator _animator;

        [Header(HeaderTitles.AnimationParams)]
        [SerializeField] private string _animationParamAngle;

        private void Update()
        {
            UpdateAngleAnimationParam();
        }

        private void UpdateAngleAnimationParam()
        {
            float angle = transform.localEulerAngles.y;
            if (angle > 202.5f)
            {
                angle -= 360.0f;
            }
            _animator.SetFloat(_animationParamAngle, angle);
        }
    }
}
