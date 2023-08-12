using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RiverPioneer : MonoBehaviour
{
    
    [SerializeField] private float moveSpeed;

    private List<Transform> lstRoadRoute;
    // 잉???
    public int moveIndex = 0;

    private Vector3 direction;
    private float playerMovedValue;
    public float PlayerMovedValue => playerMovedValue;
    private void Start()
    {
        playerMovedValue = 0f;
    }
    public void PlayerInit()
    {
        moveIndex = 0;
        lstRoadRoute = PlayerInfoManager.Instance.LstRoadRoute;

        direction = GetDirection(this.transform.position, lstRoadRoute[moveIndex].transform.position);
        direction.z = 0;
    }
    protected Vector3 GetDirection(Vector3 position, Vector3 subject)
    {
        Vector3 direction = subject - position;
        return direction.normalized;
    }
    public void Move()
    {
        Vector3 transform = this.transform.position;
        float moveValue = Time.deltaTime * moveSpeed;
        playerMovedValue += moveValue;
        this.transform.position = transform + (direction * moveValue);
        ArriveCheck();
    }

    private void ArriveCheck()
    {
        // 트랜스폼 직접적으로 접근하는게 좋지 않을 것 같음
        float distance = Vector3.Distance(this.transform.position, lstRoadRoute[moveIndex].transform.position);
        //Debug.Log($"Distance : {distance} , lstRoad : {lstRoadRoute[moveIndex].position}");
        if (distance <= 0.1f)
        {
            if (moveIndex + 1 < lstRoadRoute.Count)
            {
                // 휴식 분기점

                this.transform.position = lstRoadRoute[moveIndex].transform.position;
                ++moveIndex;
                direction = GetDirection(lstRoadRoute[moveIndex - 1].transform.position, lstRoadRoute[moveIndex].transform.position);
            }
            else
            {
                // 게임 클리어
                Destroy(this.gameObject);
            }

        }
    }
    private void FixedUpdate()
    {
        if (null == lstRoadRoute)
            return;
        Move();
    }
}
