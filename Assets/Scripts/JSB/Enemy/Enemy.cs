using System.Collections;
using System.Collections.Generic;
using UnityEngine;

enum EnemyType
{
    ET_NORMAL,
    END
}

public abstract class Enemy : MonoBehaviour
{
    
    [SerializeField] protected float attackRange;
    [SerializeField] private int enemyHealth;

    protected Transform playerPosition;

    public abstract void Attack();  
    public abstract void EnemyMove();


    public void HpDecrease(int damage)
    {
        enemyHealth -= damage;
        if(enemyHealth < 0f)
        {
        }
    }

    public void SettingEnemyInfo(Transform playerTrans)
    {
        playerPosition = playerTrans;
    }

    protected Vector3 GetDirection(Vector3 position, Vector3 subject)
    {
        Vector3 direction = subject - position;
        return direction.normalized;
    }

    private bool AttackRangeCheck()
    {
        float value = Vector3.Distance(this.transform.position, playerPosition.position);
        if (value <= attackRange)
            return true;
        else
            return false;
    }


    private void FixedUpdate()
    {
        EnemyMove();
    }
}
