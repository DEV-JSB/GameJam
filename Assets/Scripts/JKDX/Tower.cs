using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    [SerializeField]float damage;
    [SerializeField]float attackRange;
    [SerializeField]float attackSpeed;
    LayerMask enemyLayerMask;
    [SerializeField] Collider2D nearest;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Physics2D.OverlapCircle(this.transform.position, attackRange))
        {
            Collider2D[] cols = Physics2D.OverlapCircleAll(this.transform.position, attackRange);
            float nearestDis = 0;
            foreach (Collider2D col in cols)
            {
                float dis = Vector2.SqrMagnitude(col.transform.position - this.transform.position);
                if(dis > nearestDis)
                {
                    nearestDis = dis;
                    nearest = col;
                }
            }
            if(nearest != null)
            {
                Attack(nearest.gameObject);
            }
            
        }
    }

    protected  virtual void Attack(GameObject gameObject)
    {
        
    }
    protected void upgrade()
    {
        this.damage += 5;
    }
}
