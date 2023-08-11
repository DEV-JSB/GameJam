using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutsideEnemy : Enemy
{

    public override void Attack()
    {

    }

    public override void EnemyMove()
    {
        if (null == playerPosition)
            return;
        transform.position = Vector3.MoveTowards(transform.position, playerPosition.position, moveSpeed * Time.deltaTime);
    }
    // 비 효율적인 구문
    
}
