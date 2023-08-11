using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchSystem : MonoBehaviour
{
    public bool checkingTouch;

    private Vector3 mousePosition;

    private void Start()
    {
        checkingTouch = true;
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
                if (hit.rigidbody != null)
                {
                    Debug.Log("Hit");
                }
            }
            else
                Debug.Log("NotHit");
        }
    }
}
