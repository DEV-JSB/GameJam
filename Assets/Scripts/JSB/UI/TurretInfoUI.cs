using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TurretInfoUI : MonoBehaviour
{

    private Button buttonUI;
    [SerializeField] private GameObject obj;
    private void Start()
    {
        buttonUI = GetComponent<Button>();

        buttonUI.onClick.AddListener(() => {
            Debug.LogError("Info PopUp");
            obj.SetActive(false);
            });
    }
}
