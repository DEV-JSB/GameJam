using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopUI : MonoBehaviour
{
    [SerializeField] private Camera camera;
    [SerializeField] private TouchSystem touchSystem;

    //[SerializeField] private Button closeShopButton;
    [SerializeField] private Button getTurretButton;
    [SerializeField] private GameObject createProuductionUI;

    [SerializeField] private Button turretInfoButton;
    [SerializeField] private GameObject turretInfoUI;

    [SerializeField] private Button resellTurretButton;
    [SerializeField] private GameObject resellInfoUI;


    private Vector3 buildSpacePosition;
    private TowerSpace towerSpace;
    private bool startGetTurretProduction;
    private RectTransform rectTransform;

    public void InitShop(TowerSpace towerSpace,Vector3 position)
    {
        this.towerSpace = towerSpace;
        buildSpacePosition = position;
        TransformSetting();
    }
    private void OnDisable()
    {
        turretInfoButton.gameObject.SetActive(false);
    }
    private void OnEnable()
    {
        startGetTurretProduction = false;
        SettingOptionButtons();
    }

    

    private void Start()
    {
        //closeShopButton.onClick.AddListener(CloseShop);
        getTurretButton.onClick.AddListener(CreateTurret);
        rectTransform = GetComponent<RectTransform>();
    }

    private void SettingOptionButtons()
    {
        if(false == towerSpace.IsTowerCreated())
        {
            getTurretButton.gameObject.SetActive(true);
            turretInfoButton.gameObject.SetActive(false);
            resellTurretButton.gameObject.SetActive(false);
        }
        else
        {
            getTurretButton.gameObject.SetActive(false);
            turretInfoButton.gameObject.SetActive(true);
            resellTurretButton.gameObject.SetActive(true);
        }
    }

    private void TransformSetting()
    {
        GetComponent<RectTransform>().anchoredPosition = Vector2.zero;

        Vector3 pos = camera.WorldToScreenPoint(buildSpacePosition);
        pos.z = 0;
        if (null == rectTransform)
            rectTransform = GetComponent<RectTransform>();

        Vector2 canvasPos;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(rectTransform, pos, camera, out canvasPos);
        GetComponent<RectTransform>().anchoredPosition = canvasPos;

        Debug.Log($"{pos} => SettingPosition {canvasPos}");

    }

    private void CloseShop()
    {
        if (!startGetTurretProduction)
            return;
        else
            this.gameObject.SetActive(false);
    }


    private void CreateTurret()
    {
        int type = Random.Range((int)TowerType.MELEE, (int)TowerType.END);
        Debug.Log("TowerCreate");
        towerSpace.CreateTower(type);

        createProuductionUI.SetActive(true);
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
