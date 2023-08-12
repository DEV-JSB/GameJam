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
        buttonUI.onClick.AddListener(() => obj.SetActive(false));
    }
}
