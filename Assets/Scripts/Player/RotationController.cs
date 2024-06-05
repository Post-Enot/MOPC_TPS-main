using UnityEngine;

namespace MOPC
{
    public sealed class RotationController : MonoBehaviour
    {
        [SerializeField] private Animator _animator;
        [SerializeField] private LayerMask _floorLayerMask;

        private void Update()
        {
            Rotation();
        }

        private void Rotation()
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hit, float.PositiveInfinity, _floorLayerMask))
            {
                Vector3 targetPosition = new Vector3(hit.point.x, transform.position.y, hit.point.z);
                transform.LookAt(targetPosition);
            }
        }
    }
}
