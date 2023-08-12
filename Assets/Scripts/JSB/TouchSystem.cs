using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class TouchSystem : MonoBehaviour
{
    public bool checkingTouch;
    [SerializeField] private ShopUI shopUI;

    private Vector3 mousePosition;
    private bool popUpingShop;
    private GameObject prevTouchedSpace;
    private void Start()
    {
        checkingTouch = true;
        popUpingShop = false;
    }
    private void PopUpShopChecking()
    {
        mousePosition = Input.mousePosition;
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);

        RaycastHit2D hitShopSpace = Physics2D.Raycast(mousePosition, transform.forward);
        if (hitShopSpace)
        {
            GameObject obj = hitShopSpace.rigidbody.gameObject;
            if (obj == prevTouchedSpace)
            {
                shopUI.gameObject.SetActive(false);
                popUpingShop = false;
                Debug.Log("Hit And PrevSameTouch");

            }
            else if (obj.CompareTag("TurretSpace"))
            {
                if (popUpingShop && prevTouchedSpace != obj)
                {
                    //Debug.Log("Other Hit PopUp");
                    shopUI.gameObject.SetActive(false);
                    popUpingShop = false;
                    return;
                }
                else
                {
                    shopUI.InitShop(obj.GetComponent<TowerSpace>(), obj.transform.position);
                    shopUI.gameObject.SetActive(true);
                    popUpingShop = true;
                    Debug.Log("First Hit PopUp");

                }
            }
        }
        else
        {
            if (popUpingShop)
            {
                shopUI.gameObject.SetActive(false);
                popUpingShop = false;
            }
            Debug.Log("NotHit");
        }
    }
    void Update()
    {
        if (!checkingTouch)
            return;
        if (Input.GetMouseButtonDown(0))
        {
            if (EventSystem.current.IsPointerOverGameObject())
            {
                Debug.Log("UI Element clicked");
            }
            else
            {
                PopUpShopChecking();
            }
        }
    }
}
