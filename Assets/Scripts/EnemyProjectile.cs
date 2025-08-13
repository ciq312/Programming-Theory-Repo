using UnityEngine;

public class EnemyProjectile : Projectile
{
    protected override void ProjectileHit(Collider other)
    {
        if (other.CompareTag("Player")) 
        {
            Player player = other.gameObject.GetComponent<Player>();
            player.Hit(damage);
            Destroy(gameObject);
        }
    }
}
