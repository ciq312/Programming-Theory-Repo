using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : ActionCharacter
{
    [SerializeField] private float rotationSpeed;

    [SerializeField] private float rotationInput;

    [SerializeField] private GameObject fireMarkerPoint;
    
    [SerializeField] private GameObject projectilePrefab;

    [SerializeField] private int HPToHeal;
    
    void Update()
    {
        if (GameManager.instance.gameIsProccessing)
        {
            Move();
            Boundaries();
        }
    }

    private void Move()
    {
        transform.Rotate(Vector3.up * rotationInput, rotationSpeed * Time.deltaTime);
    }

    private void Boundaries()
    {
        float clampedY = Mathf.Clamp(Mathf.DeltaAngle(0, transform.eulerAngles.y), -90f, 90f);
        transform.rotation = Quaternion.Euler(transform.eulerAngles.x, clampedY, transform.eulerAngles.z);
    }

    void OnRotate(InputValue value)
    {
        rotationInput = value.Get<float>();
    }

    void OnShoot(InputValue value)
    {
        if (canShoot && GameManager.instance.gameIsProccessing)
        {
            var projectile = Instantiate(projectilePrefab, fireMarkerPoint.transform.position, projectilePrefab.transform.rotation);
            projectile.GetComponent<Projectile>().direction = (fireMarkerPoint.transform.position - transform.position).normalized;
            projectile.GetComponent<Projectile>().ShootTheProjectile();
            StartCoroutine(Reload());
        }
    }

    protected override void Dead()
    {
        GameManager.instance.gameIsProccessing = false;
        SceneManager.LoadScene(2);
    }

    public void Heal()
    {
        HP += HPToHeal;
    }

}
