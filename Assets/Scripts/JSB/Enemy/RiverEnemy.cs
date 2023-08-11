using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RiverEnemy : Enemy
{
    private List<Transform> lstRoadRoute;


    private int moveIndex = 0;

    private Vector3 direction;

    private void Start()
    {
        moveIndex = 0;
        lstRoadRoute = PlayerInfoManager.Instance.LstRoadRoute;

        direction = GetDirection(this.transform.position, lstRoadRoute[moveIndex].transform.position);
        direction.z = 0;
    }
    public override void Attack()
    {

    }

    public override void EnemyMove()
    {
        Vector3 transform = this.transform.position;
        float moveValue = Time.deltaTime * moveSpeed;
        this.transform.position = transform + (direction * moveValue);
        ArriveCheck();
    }
    
    private void ArriveCheck()
    {
        // Ʈ������ ���������� �����ϴ°� ���� ���� �� ����
        float distance = Vector3.Distance(this.transform.position, lstRoadRoute[moveIndex].transform.position);
        if(distance <= 0.1f)
        {
            if (moveIndex + 1 < lstRoadRoute.Count)
            {
                this.transform.position = lstRoadRoute[moveIndex].transform.position;
                ++moveIndex;
                direction = GetDirection(lstRoadRoute[moveIndex - 1].transform.position, lstRoadRoute[moveIndex].transform.position);
            }
            else
                Destroy(this.gameObject);
        }
    }

}
