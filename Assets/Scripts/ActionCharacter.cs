using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ActionCharacter : MonoBehaviour
{
    [SerializeField] protected int MaxHP;
    [SerializeField] protected int _HP;
    [SerializeField] protected Image HPBar;
    
    public int HP
    {
        get => _HP;
        protected set
        {
            _HP = value >= MaxHP ? MaxHP : value; // if HP more than MaxHP set MaxHP
            _HP = value <= 0 ? 0 : value; // HP couldn't be less than zero
            UpdateHPBar();
        }
    }
    private void OnValidate()
    {
        //Inspector value change check
        
        if (_HP < 0)
            _HP = 0;
    }
    
    [SerializeField] protected int damage;
    
    [SerializeField] protected float reloadTime;

    [SerializeField] protected bool canShoot = true;
    
    public virtual void Hit(int damage)
    {
        HP -= damage; 
        if (HP == 0)
            Dead();
    }

    protected virtual void Dead()
    {
        Destroy(gameObject);
    }

    protected virtual void UpdateHPBar()
    {
        
        HPBar.fillAmount = (float)HP / (float) MaxHP;
    }   
    protected IEnumerator<WaitForSeconds> Reload() 
    {
        canShoot = false;
        yield return new WaitForSeconds(reloadTime);
        canShoot = true;
    }
}
