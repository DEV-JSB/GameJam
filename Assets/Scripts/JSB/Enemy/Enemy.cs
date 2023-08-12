using System.Collections;
using System.Collections.Generic;
using UnityEngine;

enum EnemyType
{
    ET_NORMAL,
    ET_HARD,
    ET_HELL,
    END
}

public abstract class Enemy : MonoBehaviour
{
    [SerializeField] protected float originMoveSpeed;
    [SerializeField] protected float moveSpeed;
    [SerializeField] protected float attackCooltime;
    [SerializeField] protected float attackRange;
    [SerializeField] protected int enemyPower;
    [SerializeField] private int enemyHealth;
    [SerializeField] private int money;

    [SerializeField] bool isSlowed;
    protected Transform playerPosition;

    private float attackCoolTimer;
    public abstract void Attack();  
    public abstract void EnemyMove();
    private void Start()
    {
        isSlowed = false;
    }
    public void HpDecrease(int damage)
    {
        enemyHealth -= damage;
        StartCoroutine(Damaged());
        //Debug.Log("데미지 받음");
        if(enemyHealth < 0f)
        {
            PlayerInfoManager.Instance.IncreaseMoney(money);
            Destroy(this.gameObject);
        }
    }
    public void SpeedDecrease(int decrease)
    {
        if(isSlowed == false)
        {
            moveSpeed = moveSpeed - moveSpeed / decrease;
        }
        isSlowed = true;
        
        StopCoroutine(SlowTime());
        StartCoroutine(SlowTime());
        
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

    IEnumerator SlowTime()
    {
        yield return new WaitForSeconds(3f);
        isSlowed = false;
        moveSpeed = originMoveSpeed;
    }

    IEnumerator Damaged()
    {
        Color originColor = this.GetComponentInChildren<SpriteRenderer>().color;
        this.GetComponentInChildren<SpriteRenderer>().color = Color.red;
        yield return new WaitForSeconds(0.1f);
        this.GetComponentInChildren<SpriteRenderer>().color = originColor;

    }
}
