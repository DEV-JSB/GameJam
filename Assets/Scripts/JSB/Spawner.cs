using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    enum EnemyType
    {
        OUTSIDE,
        END
    }
    enum SpawnPivot
    {
        SP_ROW,
        SP_COLUM,
    }

    [SerializeField] private Transform player;
    [Header("적이 증가한다면 타입에 맞춰서 적 프리펩을 넣어야함")]
    [SerializeField] private List<GameObject> lstEnemyPrefabs;

    [SerializeField] private SpawnPivot spawnPivot;
    [SerializeField] private int spawnCount;
    [SerializeField] private float range;
    [SerializeField] private float spawnCoolTime;

    private EnemyType createdType;
    private float timer;
    private void CreateEnemy()
    {
        int type = Random.Range(0, (int)EnemyType.END);
        createdType = (EnemyType)type;

        float correctionValue = Random.Range(-range, range); 
        Vector3 spawnPoint = this.transform.position;
        switch(spawnPivot)
        {
            case SpawnPivot.SP_COLUM:
                spawnPoint.y += correctionValue;
                break;
            case SpawnPivot.SP_ROW:
                spawnPoint.x += correctionValue;
                break;
        }
        GameObject createdEnemy = GameObject.Instantiate(lstEnemyPrefabs[type], spawnPoint,Quaternion.identity,null);
        SettingEnemy(createdEnemy);
    }

    private void SettingEnemy(GameObject createdEnemy)
    {
        switch(createdType)
        {
            case EnemyType.OUTSIDE:
                createdEnemy.GetComponent<OutsideEnemy>().SettingEnemyInfo(player);
                break;
        }
    }

    private void Update()
    {
        if (timer >= spawnCoolTime)
        {
            for(int i = 0; i < spawnCount; ++i)
            CreateEnemy();
            timer = 0;
        }
        else
            timer += Time.deltaTime;
    }
}
