using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArcherTower : Tower
{
    [SerializeField] Collider2D nearest;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    protected override void Attack(Collider2D[] cols)
    {
        foreach (Collider2D col in cols)
        {
            float nearestDis = 0;
            float dis = Vector2.SqrMagnitude(col.transform.position - this.transform.position);
            if (dis > nearestDis)
            {
                nearestDis = dis;
                nearest = col;
            }
            
        }
        if(nearest != null)
        {
            nearest.GetComponent<Enemy>().HpDecrease(damage);
        }
    }
}
