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
    private GameObject tower;
    private TowerType towerType;

    private int investValue;
    public int InvestValue => investValue;

    public bool IsTowerCreated()
    {
        if (null != tower)
            return true;
        else
            return false;
    }
    public void CreateTower(GameObject ramdomTower)
    {
        tower = GameObject.Instantiate(ramdomTower, this.transform);
    }
    public void DestroyTower()
    {
        GameObject.Destroy(tower);
        tower = null;
    }
    


}
