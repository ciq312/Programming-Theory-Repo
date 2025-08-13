using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] protected int damage;

    [SerializeField] protected float speed;
    
    [SerializeField] public Vector3 direction;
    
    [SerializeField] private float lifetime;

    private Rigidbody projectileRb;

    void Awake()
    {
        projectileRb = GetComponent<Rigidbody>();
        StartCoroutine(ProjectileRoutine());
    }

    public void ShootTheProjectile()
    {
        projectileRb.AddForce(direction.normalized * speed, ForceMode.Impulse);
    }

    public void OnTriggerEnter(Collider other)
    {
        ProjectileHit(other);
    }

    protected virtual void ProjectileHit(Collider other)
    {
        
    }

    IEnumerator<WaitForSeconds> ProjectileRoutine()
    {
        yield return new WaitForSeconds(lifetime);
        Destroy(gameObject);
    }
}
