using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchSystem : MonoBehaviour
{
    public bool checkingTouch;
    [SerializeField] private ShopUI shopUI;

    private Vector3 mousePosition;
    private bool popUpingShop;
    private void Start()
    {
        checkingTouch = true;
        popUpingShop = false;
    }
    void Update()
    {
        if (!checkingTouch)
            return;
        if (Input.GetMouseButtonDown(0))
        {
            mousePosition = Input.mousePosition;
            mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);


            RaycastHit2D hit = Physics2D.Raycast(mousePosition, transform.forward);

            if (hit)
            {
                if (hit.rigidbody.gameObject.CompareTag("TurretSpace"))
                {
                    shopUI.SettingPosition(hit.rigidbody.gameObject.transform.position);
                    shopUI.gameObject.SetActive(true);
                    popUpingShop = true;
                }
            }
            else
            {
                if(popUpingShop)
                {
                    shopUI.gameObject.SetActive(false);
                    popUpingShop = false;
                }
                Debug.Log("NotHit");
            }
        }
    }
}
