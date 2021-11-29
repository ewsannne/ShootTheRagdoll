using ShootTheRagdoll.Ragdoll;
using UnityEngine;

namespace ShootTheRagdoll.Player.Weapon
{
    [RequireComponent(typeof(Rigidbody))]
    public class PlayerProjectile : MonoBehaviour
    {
        [SerializeField] private float speed = 40f;
        [SerializeField] private PlayerProjectileForceSettingsSO forceSettings;
        
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
            Vector3 force = transform.forward * speed;
            _rigidbody.AddForce(force, ForceMode.Impulse);
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
            
            ragdollController.Die(transform.forward * forceSettings.ForceOnImpact, other.attachedRigidbody);
        }
        
    }
}
