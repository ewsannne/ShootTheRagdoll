using UnityEngine;
using UnityEngine.InputSystem;

namespace ShootTheRagdoll.Player.Aim
{
    public class AimTargetPositionController : MonoBehaviour
    {
        [SerializeField] private new Camera camera;


        private void Update()
        {
            Ray ray = camera.ScreenPointToRay(Mouse.current.position.ReadValue());
            if (Physics.SphereCast(ray, 0.2f, out RaycastHit hit))
            {
                transform.position = hit.point;
            }
        }
    }
}
