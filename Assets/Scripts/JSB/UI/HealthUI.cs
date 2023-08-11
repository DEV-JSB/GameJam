using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthUI : MonoBehaviour
{
    [SerializeField] private Sprite blackOutImage;
    [SerializeField] private Sprite healthImage;

    [SerializeField] private List<Image> lstHealthImage;


    public void InitHealth(int health)
    {
        for (int i = 0; i < health; ++i)
            lstHealthImage[i].gameObject.SetActive(true);
    }

    public void UpdateHealthInfo(int health , int maxHealth)
    {
        for (int i = 0; i < health; ++i)
            lstHealthImage[i].sprite = healthImage;
        for(int i = health; i < maxHealth; ++i)
            lstHealthImage[i].sprite = blackOutImage;

    }
}
