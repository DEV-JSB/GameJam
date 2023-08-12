using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RandomUnitProduceWindow : MonoBehaviour
{

    public Action productionFInish;

    [SerializeField] private List<GameObject> lstRandomUnit;

    [SerializeField] private float unscaledTimeCorrectionValue;
    [SerializeField] private float productionTime;
    [SerializeField] private float translateTime;

    [SerializeField] private Button buttonUI;
    private GameObject prevShowedObject;
    private int randomIndex;

    private float productionTimer;


    private void RandomShow()
    {
        if (null != prevShowedObject)
            prevShowedObject.SetActive(false);
        randomIndex = UnityEngine.Random.Range(0, lstRandomUnit.Count);
        prevShowedObject = lstRandomUnit[randomIndex];
        lstRandomUnit[randomIndex].SetActive(true);

    }
    private void OnEnable()
    {
        Time.timeScale = 0f;
        RandomShow();
        StartCoroutine(nameof(StartRandomShowing));
        buttonUI.onClick.AddListener(
            () => {
                this.gameObject.SetActive(false);
                buttonUI.gameObject.SetActive(false);
            });

    }

    IEnumerator StartRandomShowing()
    {
        productionTimer = productionTime;
        float value = 0f;
        while (productionTimer > 0f)
        {
            value += unscaledTimeCorrectionValue * Time.unscaledDeltaTime;
            yield return new WaitForSecondsRealtime(translateTime);
            productionTimer -= value;

            RandomShow();
        }
        this.gameObject.SetActive(false);
        Time.timeScale = 1f;
        buttonUI.gameObject.SetActive(true);
        productionFInish();
    }

}
