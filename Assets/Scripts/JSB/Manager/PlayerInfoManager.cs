using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInfoManager : MonoBehaviour
{
    static private PlayerInfoManager instance;
    public static PlayerInfoManager Instance
    {
        get
        {
            if (null == instance)
                return null;
            return instance;
        }
    }
    [SerializeField] private MoneyUI moneyUI;
    [SerializeField] private HealthUI healthUI;
    [SerializeField] private int playerMaxHealth;
    private int health;
    
    private int money;

    private void Awake()
    {
        instance = this;
        DontDestroyOnLoad(this.gameObject);
    }

    private void Start()
    {
        healthUI.InitHealth(playerMaxHealth);
    }
    public void DecreaseHealth(int value)
    {
        if (0 < health - value)
        {
            // 게임 오버
            health = 0;
        }
        else
            health -= value;

        healthUI.UpdateHealthInfo(health, playerMaxHealth);
    }

    public void IncreaseMoney(int cash)
    {
        money += cash;
        moneyUI.UpdateMoneyText(money);
    }


    public bool MoneyCheck(int cash)
    {
        if (cash <= money)
        {
            DecreaseMoney(cash);
            return true;
        }
        else
            return false;
    }
    private void DecreaseMoney(int cash)
    {
        moneyUI.UpdateMoneyText(money);
        money -= cash;
    }
}
