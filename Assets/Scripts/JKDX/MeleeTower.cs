using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeTower : Tower
{


    // Start is called before the first frame update
    void Start()
    {
        this.isAbleToAttack = true;
    }

    // Update is called once per frame
    void Update()
    {
        SurchEnemy();
    }
    protected override void Attack(Collider2D[] cols)
    {
        SoundManager.Instance.SwordAttackSound();
        foreach (Collider2D col in cols)
        {
            if(col !=null)
            {
                col.GetComponent<Enemy>().HpDecrease(damage);
            }
            Debug.Log("meleeAttack");
        }
    }
    
}
