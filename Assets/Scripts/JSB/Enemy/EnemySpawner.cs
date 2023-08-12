using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    enum EnemySawpnType
    {
        EASY,
        NORMAL,
        HARD,
        RIVER,
    }
    enum SpawnPivot
    {
        SP_ORIGIN,
        SP_ROW,
        SP_COLUM,
    }

    [SerializeField] private int curLevel;
    [SerializeField] private Transform player;
    [Header("적이 증가한다면 타입에 맞춰서 적 프리펩을 넣어야함")]
    [SerializeField] private List<GameObject> lstEnemyPrefabs;

    [SerializeField] private SpawnPivot spawnPivot;
    [SerializeField] private int spawnCount;
    [SerializeField] private float range;
    [SerializeField] private float spawnCoolTime;


    [SerializeField] private float normalPivotPercent;
    [SerializeField] private float hardPivotPercent;


    private float timer;


    private int GetEnemyType()
    {
        int type = 0;
        float percent = PlayerInfoManager.Instance.ProgressPrecent;
        if(percent > hardPivotPercent)
        {
            type = Random.Range(0, (int)EnemyType.END);
        }
        else if(percent > normalPivotPercent)
        {
            type = Random.Range(0, (int)EnemyType.ET_HELL);

        }
        else
        {
            type = Random.Range(0, (int)EnemyType.ET_NORMAL);
        }
        return type;
    }

    private void CreateEnemy()
    {
        int type = GetEnemyType();

        float correctionValue = Random.Range(-range, range); 
        Vector3 spawnPoint = this.transform.position;
        switch(spawnPivot)
        {
            case SpawnPivot.SP_ORIGIN:
                break;
            case SpawnPivot.SP_COLUM:
                spawnPoint.y += correctionValue;
                break;
            case SpawnPivot.SP_ROW:
                spawnPoint.x += correctionValue;
                break;
        }
        GameObject createdEnemy = GameObject.Instantiate(lstEnemyPrefabs[type], spawnPoint,Quaternion.identity,null);
        createdEnemy.transform.Rotate(new Vector3(0,0,-90));
        createdEnemy.GetComponent<Enemy>().SettingEnemyInfo(player);
    }





    private void Update()
    {

        float percent = PlayerInfoManager.Instance.ProgressPrecent;
        if(percent >= 10 * curLevel)
        {
            curLevel++;
        }
        if (percent < 10f)
            return;
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
