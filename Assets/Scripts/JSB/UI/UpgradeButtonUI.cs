using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class UpgradeButtonUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI text;

    private int upgradeCoast = 10;
    private int nowGrade = 1;
    private Button button;
    private void Start()
    {
        button = this.GetComponent<Button>();
        button.onClick.AddListener(UpgradeFakeButton);
    }

    private void UpgradeFakeButton()
    {
        Debug.Log("Upgrade Update");
        if (nowGrade >= 5)
            return;
        if(PlayerInfoManager.Instance.MoneyCheck(upgradeCoast))
        {
            ++nowGrade;
            text.text = $"+{nowGrade}";
        }
    }
}
