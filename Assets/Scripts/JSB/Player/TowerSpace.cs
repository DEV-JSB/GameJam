using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum TowerType
{
    MELEE,
    ARCHER,
    SPECIAL,
    END
}
public class TowerSpace : MonoBehaviour
{
    [SerializeField] private List<GameObject> lstTowers;
    private GameObject tower;
    private TowerType towerType;


    public bool IsTowerCreated()
    {
        if (null != tower)
            return true;
        else
            return false;
    }
    public void CreateTower(int type)
    {
        tower = GameObject.Instantiate(lstTowers[type], this.transform);
    }



}
