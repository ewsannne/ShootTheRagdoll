using ShootTheRagdoll.Utility;
using UnityEngine;
using UnityEngine.InputSystem;

namespace ShootTheRagdoll.Input
{
    public class PointerWorldPositionCalculator : Singleton<PointerWorldPositionCalculator>
    {
        [SerializeField] private new Camera camera;
        
        
        public PointerWorldPosition GetPosition()
        {
            PointerWorldPosition simplifiedHit = new PointerWorldPosition();
            
            Ray ray = camera.ScreenPointToRay(Pointer.current.position.ReadValue());
            simplifiedHit.HasPosition = Physics.Raycast(ray, out RaycastHit hit, 40f);
            
            if (simplifiedHit.HasPosition)
            {
                simplifiedHit.Position = hit.point;
            }

            return simplifiedHit;
        }
        
        
        public PointerWorldPosition GetPosition(LayerMask layerMask)
        {
            PointerWorldPosition simplifiedHit = new PointerWorldPosition();
            
            Ray ray = camera.ScreenPointToRay(Pointer.current.position.ReadValue());
            simplifiedHit.HasPosition = Physics.Raycast(ray, out RaycastHit hit, 40f, layerMask);
            
            if (simplifiedHit.HasPosition)
            {
                simplifiedHit.Position = hit.point;
            }

            return simplifiedHit;
        }
    }
}
