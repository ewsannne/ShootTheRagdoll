using ShootTheRagdoll.Input;
using ShootTheRagdoll.Utility;
using UnityEngine;

namespace ShootTheRagdoll.Player.Aim
{
    public class AimTargetPositionController : MonoBehaviour
    {
        private void Update()
        {
            MoveToPointerPosition();
        }


        private void MoveToPointerPosition()
        {
            PointerWorldPosition pointerWorldPosition = PointerWorldPositionCalculator.Instance.GetPosition();
            if (pointerWorldPosition.HasPosition)
            {
                transform.position = pointerWorldPosition.Position;
            }
        }
    }
}
