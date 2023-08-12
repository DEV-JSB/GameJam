using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SellingUI : MonoBehaviour
{
    [SerializeField] private Button cancelButton;
    [SerializeField] private Button sellingButton;

    private TowerSpace towerSpace;

    public void InitSellingUI(TowerSpace towerSpace)
    {
        this.towerSpace = towerSpace;
    }
    private void Start()
    {
        cancelButton.onClick.AddListener(() => this.gameObject.SetActive(false));
        sellingButton.onClick.AddListener(SellingTower);
    }
    public void SellingTower()
    {
        PlayerInfoManager.Instance.IncreaseMoney(towerSpace.InvestValue);
        // int ������ Ÿ�� ������ �޾ƿ´�
        towerSpace.DestroyTower();
        
    }

}
