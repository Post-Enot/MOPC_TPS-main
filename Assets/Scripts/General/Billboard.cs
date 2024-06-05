using UnityEngine;

namespace MOPC
{
    public sealed class Billboard : MonoBehaviour
    {
        [Header(HeaderTitles.ComponentReferences)]
        [SerializeField] private Camera _camera;

        [Header(HeaderTitles.Params)]
        [SerializeField] private bool _allowYRotation;

        private void Awake()
        {
            InitCameraReference();
        }

        private void LateUpdate()
        {
            UpdateRotation();
        }

        private void InitCameraReference()
        {
            if (_camera == null)
            {
                _camera = Camera.main;
            }
        }

        private void UpdateRotation()
        {
            if (_allowYRotation)
            {
                UpdateRotationXYZ();
            }
            else
            {
                UpdateRotationXZ();
            }
        }

        private void UpdateRotationXZ()
        {
            Vector3 cameraForwardXZ = Vector3.ProjectOnPlane(_camera.transform.forward, Vector3.up);
            cameraForwardXZ = cameraForwardXZ.normalized;
            Vector3 targetPosition = transform.position - cameraForwardXZ;
            transform.LookAt(targetPosition);
        }

        private void UpdateRotationXYZ()
        {
            Vector3 targetPosition = transform.position - _camera.transform.forward;
            Vector3 worldUp = _camera.transform.rotation * Vector3.up;
            transform.LookAt(targetPosition, worldUp);
        }
    }
}
