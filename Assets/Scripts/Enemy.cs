using UnityEngine;
using UnityEngine.InputSystem;

public class Enemy : ActionCharacter
{

    [SerializeField] private float moveSpeed;

    [SerializeField] private float attackRange;

    [SerializeField] protected int scoreForEnemy;
    
    protected GameObject player;

    private MainScreenUI UI;

    private bool isRunning;

    private Rigidbody enemyRb;

    void Awake()
    {
        UI = GameObject.Find("MainCanvas").GetComponent<MainScreenUI>();
        isRunning = true;
        player = GameObject.Find("Player");
        enemyRb = GetComponent<Rigidbody>();
    }

    protected void FixedUpdate()
    {
        if (GameManager.instance.gameIsProccessing)
        {
            if (GameManager.instance.gameIsProccessing && isRunning)
                MoveTowardsPlayer();
            float distance = Vector3.Distance(player.transform.position, transform.position);
            if ((distance <= attackRange) && canShoot)
            {
                Attack();   
                isRunning = false;
                StartCoroutine(Reload());
            }
        }
    }
    private void MoveTowardsPlayer()
    {
        Vector3 moveDirection = (player.transform.position - transform.position).normalized;
        
        Vector3 movement = moveDirection * (moveSpeed * Time.deltaTime);

        enemyRb.MovePosition(transform.position + movement);
        
        transform.LookAt(player.transform);
    }

    protected virtual void Attack()
    {
        if (player != null)
        {
            Player playerScript = player.GetComponent<Player>();
        
            playerScript.Hit(damage);
        }

    }
    

    protected override void Dead()
    {
        player.GetComponent<Player>().Heal();
        UI.UpdateScoreText();
        GameManager.instance.UpdateScore(scoreForEnemy);
        Destroy(gameObject);
    }

}
