using Unity.VisualScripting;
using UnityEngine;

public class PlayerProjectile : Projectile
{
    protected override void ProjectileHit(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            Enemy enemy = other.gameObject.GetComponent<Enemy>();
            enemy.Hit(damage);
            Destroy(gameObject);
        }
    }
}
