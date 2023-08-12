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
    [SerializeField] private RandomUnitProduceWindow produceWindow;
    [SerializeField] private SpriteRenderer spaceRenderer;
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
        spaceRenderer.enabled = false;
        tower.SetActive(false);
        produceWindow.productionFInish = null;
        produceWindow.productionFInish += () => tower.SetActive(true);
    }
    public void SettingTowerOn()
    {
        tower.SetActive(true);
    }

    public void DestroyTower()
    {
        GameObject.Destroy(tower);
        spaceRenderer.enabled = false;
        tower = null;
    }
    


}
