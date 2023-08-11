using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class MoneyUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI moneyText;


    public void UpdateMoneyText(int money)
    {
        moneyText.text = "GOLD : " + money.ToString() + "G";
    }
}
