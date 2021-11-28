using UnityEngine;

namespace ShootTheRagdoll.Player.Weapon
{
    public class PlayerProjectile : MonoBehaviour
    {
        private Rigidbody _rigidbody;
    
    
        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody>();
        }


        private void Start()
        {
            _rigidbody.AddForce(transform.forward * 100f, ForceMode.Impulse);
        }


        private void OnTriggerEnter(Collider other)
        {
            Destroy(gameObject);
        }
    }
}
