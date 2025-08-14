using UnityEngine;

public class ArcherEnemy : Enemy
{
    public GameObject projectile;
    protected override void Attack()
    {
        projectile = Instantiate(projectile, transform.position, projectile.transform.rotation);
        
        projectile.GetComponent<EnemyProjectile>().direction = (player.transform.position - transform.position).normalized;
        
        projectile.GetComponent<EnemyProjectile>().ShootTheProjectile();
    }
}
