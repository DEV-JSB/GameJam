using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    public abstract void Attack();  
    public abstract void EnemyMove();

    protected Vector3 GetDirection(Vector3 position, Vector3 subject)
    {

        Vector3 direction = subject - position;
        return direction.normalized;
    }
}
