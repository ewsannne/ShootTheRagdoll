using UnityEngine;

namespace ShootTheRagdoll.Ragdoll
{
    [RequireComponent(typeof(Animator))]
    public class RagdollController : MonoBehaviour
    {
        private Animator _animator;
        private Rigidbody[] _ragdollParts;


        public void Die(Vector3 force, Rigidbody bodyPart)
        {
            EnableRagdoll();
            ApplyForceToShotBodyPart(force, bodyPart);
        }


        private void ApplyForceToShotBodyPart(Vector3 force, Rigidbody bodyPart)
        {
            bodyPart.AddForce(force, ForceMode.Impulse);
        }
        
        
        private void Awake()
        {
            GetComponents();
            DisableRagdoll();
        }


        private void GetComponents()
        {
            _animator = GetComponent<Animator>();
            _ragdollParts = GetComponentsInChildren<Rigidbody>();
        }


        private void DisableRagdoll()
        {
            ToggleRagdoll(false);
        }
        
        
        private void EnableRagdoll()
        {
            ToggleRagdoll(true);
        }


        private void ToggleRagdoll(bool state)
        {
            foreach (Rigidbody part in _ragdollParts)
            {
                _animator.enabled = !state;
                part.isKinematic = !state;
            }
        }
    }
}
