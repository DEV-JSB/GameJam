using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchSystem : MonoBehaviour
{
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit))
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
