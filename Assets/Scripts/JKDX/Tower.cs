using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Spine.Unity;
public class Tower : MonoBehaviour
{
    [SerializeField] protected int damage;
    [SerializeField]float attackRange;
    [SerializeField]float attackSpeed;
    [SerializeField] LayerMask enemyLayerMask;
    [SerializeField] Collider2D[] colss;
    [SerializeField] protected bool isAbleToAttack;
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
        if (isAbleToAttack == false)
            return;
        Collider2D[] cols = Physics2D.OverlapCircleAll(this.transform.position, attackRange, enemyLayerMask);
        if (cols.Length > 0)
        {
            colss = cols;
            Attack(cols);
            StartCoroutine(AttackCor());
            if(this.GetComponent<SkeletonAnimation>() != null)
                this.GetComponent<SkeletonAnimation>().AnimationName = "attack";

        }
        else
        {
            if (this.GetComponent<SkeletonAnimation>() != null)
                this.GetComponent<SkeletonAnimation>().AnimationName = "idle";
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
    IEnumerator AttackCor()
    {
        isAbleToAttack = false;
        yield return new WaitForSeconds(attackSpeed);
        isAbleToAttack = true;
    }

    protected virtual void SetAnimation()
    {
        this.GetComponent<SkeletonAnimation>().AnimationName = "attack";
    }
}
