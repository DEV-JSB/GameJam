using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomUnitProduceWindow : MonoBehaviour
{
    [SerializeField] private List<GameObject> lstRandomUnit;

    [SerializeField] private float productionTime;
    [SerializeField] private float translateTime;

    private GameObject prevShowedObject;
    private int randomIndex;

    private float productionTimer;


    private void RandomShow()
    {
        if (null != prevShowedObject)
            prevShowedObject.SetActive(false);
        randomIndex = Random.Range(0, lstRandomUnit.Count);
        prevShowedObject = lstRandomUnit[randomIndex];
        lstRandomUnit[randomIndex].SetActive(true);

    }
    private void Start()
    {
        RandomShow();
        StartCoroutine(nameof(StartRandomShowing));
    }

    IEnumerator StartRandomShowing()
    {
        productionTimer = productionTime;
        while (productionTimer > 0f)
        {
            yield return new WaitForSecondsRealtime(translateTime);
            productionTimer -= Time.deltaTime;

            RandomShow();
        }
    }

}
