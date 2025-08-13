using UnityEngine;
using UnityEngine.InputSystem;

public class Enemy : ActionCharacter
{

    [SerializeField] private float moveSpeed;
    
    private GameObject player;

    private Rigidbody enemyRb;

    void Awake()
    {
        player = GameObject.Find("Player");
        enemyRb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        MoveTowardsPlayer();
    }
    private void MoveTowardsPlayer()
    {
        Vector3 moveDirection = (player.transform.position - transform.position).normalized;
        
        Vector3 movement = moveDirection * (moveSpeed * Time.deltaTime);

        enemyRb.MovePosition(transform.position + movement);
    }

    protected virtual void Attack()
    {
        Player playerScript = player.GetComponent<Player>();
        
        playerScript.Hit(damage);
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Attack();
        }
    }

}
