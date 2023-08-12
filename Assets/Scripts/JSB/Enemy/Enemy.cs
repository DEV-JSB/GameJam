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
    [SerializeField] protected float moveSpeed;
    [SerializeField] protected float attackCooltime;
    [SerializeField] protected float attackRange;
    [SerializeField] protected int enemyPower;
    [SerializeField] private int enemyHealth;
    [SerializeField] private int money;
    protected Transform playerPosition;

    private float attackCoolTimer;
    public abstract void Attack();  
    public abstract void EnemyMove();

    public void HpDecrease(int damage)
    {
        enemyHealth -= damage;
        Debug.Log("데미지 받음");
        if(enemyHealth < 0f)
        {
            PlayerInfoManager.Instance.IncreaseMoney(money);
            Destroy(this.gameObject);
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
        if (false == AttackRangeCheck())
            EnemyMove();
        else
        {
            if (attackCoolTimer >= attackCooltime)
            {
                attackCoolTimer = 0f;
                Attack();
            }
            else
                attackCoolTimer += Time.deltaTime;
        }
    }
}
