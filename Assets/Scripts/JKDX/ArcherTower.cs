using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArcherTower : Tower
{
    [SerializeField] Collider2D nearest;
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
        Debug.Log("아처가 적 감지");
        float nearestDis = 0;
        for(int i =0; i<cols.Length;i++)
        {
            float dis = Vector2.SqrMagnitude(cols[i].transform.position - this.transform.position);
            if (i == 0)
            {
                nearestDis = dis;
                nearest = cols[i];
                
            }
            else if (dis < nearestDis)
            {
                nearestDis = dis;
                nearest = cols[i];
            }
        }
  
        if(nearest != null)
        {
            nearest.GetComponent<Enemy>().HpDecrease(damage);
            //Debug.Log("화살공격");
        }
    }

}
