using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutsideEnemy : Enemy
{

    [SerializeField] private float moveValue;


    public override void Attack()
    {

    }

    public override void EnemyMove()
    {
        if (null == playerPosition)
            return;
        transform.position = Vector3.MoveTowards(transform.position, playerPosition.position,moveValue * Time.deltaTime);
    }
    // 비 효율적인 구문
    
}
