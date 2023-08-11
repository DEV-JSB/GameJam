using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopUI : MonoBehaviour
{
    [SerializeField] private TouchSystem touchSystem;
    [SerializeField] private Button closeShopButton;
    [SerializeField] private Button getTurretButton;

    private bool startGetTurretProduction;
    
    private void OnEnable()
    {
        startGetTurretProduction = false;
        touchSystem.checkingTouch = false;
    }
    private void Start()
    {
        closeShopButton.onClick.AddListener(CloseShop);
        getTurretButton.onClick.AddListener(CreateTurret);
    }

    private void CloseShop()
    {
        if (!startGetTurretProduction)
            return;
        else
            this.gameObject.SetActive(false);
    }

    private void SettingTurretType()
    {

    }
    private void CreateTurret()
    {
        SettingTurretType();
        // 터랫 생성 로직
        StartCoroutine(nameof(StartGetTurretProdiction));
    }

    private IEnumerator StartGetTurretProdiction()
    {
        Debug.Log("연출 시작!");
        startGetTurretProduction = true;
        yield return new WaitForSeconds(5f);
        Debug.Log("연출 끝!");
        startGetTurretProduction = false;
    }


}
