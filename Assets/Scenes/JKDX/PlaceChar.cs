using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceChar : MonoBehaviour
{
   
    Vector3 mousePos;
    
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void placeCharacter(GameObject character)
    {
        
        mousePos = Input.mousePosition;
        mousePos = Camera.main.ScreenToWorldPoint(mousePos);
        //Vector3 gridpos = 
        //character.transform.position = 
    }
}
