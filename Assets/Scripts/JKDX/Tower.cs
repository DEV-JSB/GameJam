using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    [SerializeField] protected int damage;
    [SerializeField]float attackRange;
    [SerializeField]float attackSpeed;
    [SerializeField] LayerMask enemyLayerMask;
    [SerializeField] Collider2D[] colss;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    protected  virtual void Attack(Collider2D[] cols)
    {
        
    }
    protected void SurchEnemy()
    {
        Debug.Log("스크립트 이상 무");
        Collider2D[] cols = Physics2D.OverlapCircleAll(this.transform.position, attackRange, enemyLayerMask);
        if (cols.Length > 0)
        {
            
            colss = cols;
            Attack(cols);

        }
    }
    protected void upgrade()
    {
        this.damage += 5;
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(this.transform.position, attackRange);
    }
}
