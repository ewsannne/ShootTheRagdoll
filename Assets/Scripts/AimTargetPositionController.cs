using UnityEngine;
using UnityEngine.InputSystem;

namespace ShootTheRagdoll
{
    public class AimTargetPositionController : MonoBehaviour
    {
        [SerializeField] private Camera camera;


        private void Update()
        {
            Ray ray = camera.ScreenPointToRay(Mouse.current.position.ReadValue());
            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                transform.position = hit.point;
            }
        }
    }
}
