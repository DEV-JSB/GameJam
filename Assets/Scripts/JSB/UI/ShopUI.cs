using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopUI : MonoBehaviour
{
    [SerializeField] private Camera camera;
    [SerializeField] private TouchSystem touchSystem;
    //[SerializeField] private Button closeShopButton;
    //[SerializeField] private Button getTurretButton;

    private Vector3 buildSpacePosition;

    private bool startGetTurretProduction;
    private RectTransform rectTransform;

    public void SettingPosition(Vector3 position)
    {
        buildSpacePosition = position;
        TransformSetting();
    }
    private void OnEnable()
    {
        startGetTurretProduction = false;
    }
    private void Start()
    {
        //closeShopButton.onClick.AddListener(CloseShop);
        //getTurretButton.onClick.AddListener(CreateTurret);
        rectTransform = GetComponent<RectTransform>();
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
