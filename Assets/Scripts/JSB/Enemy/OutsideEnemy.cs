using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutsideEnemy : Enemy
{

    [SerializeField] private float moveValue;


    private Transform playerPosition;   

    public void SettingEnemyInfo(Transform playerTrans)
    {
        playerPosition = playerTrans;
    }
    public override void Attack()
    {
        throw new System.NotImplementedException();
    }

    public override void EnemyMove()
    {
        transform.position = Vector3.MoveTowards(transform.position, playerPosition.position,moveValue * Time.deltaTime);
    }
    // 비 효율적인 구문
    private void FixedUpdate()
    {
        if (null == playerPosition)
            return;
        EnemyMove();
    }
}
