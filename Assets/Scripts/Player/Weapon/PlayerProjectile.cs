using ShootTheRagdoll.Ragdoll;
using UnityEngine;

namespace ShootTheRagdoll.Player.Weapon
{
    [RequireComponent(typeof(Rigidbody))]
    public class PlayerProjectile : MonoBehaviour
    {
        private Rigidbody _rigidbody;

        private bool DidHit(string layerName, Component other) =>
            other.gameObject.layer == LayerMask.NameToLayer(layerName);
        
    
        private void Awake()
        {
            GetRigidBody();
            ApplyInitialForce();
        }


        private void GetRigidBody()
        {
            _rigidbody = GetComponent<Rigidbody>();
        }


        private void ApplyInitialForce()
        {
            _rigidbody.AddForce(transform.forward * 50f, ForceMode.Impulse);
        }
        
        
        // Refactor if going to add destroyable objects and/or chickens
        private void OnTriggerEnter(Collider other)
        {
            if (DidHit("Enemy", other))
            {
                KillEnemy(other);
            }
            
            Destroy(gameObject);
        }


        private void KillEnemy(Collider other)
        {
            Transform root = other.transform.root;
            RagdollController ragdollController = root.GetComponent<RagdollController>();
            
            ragdollController.Die(_rigidbody.velocity, other.attachedRigidbody);
        }
        
    }
}
