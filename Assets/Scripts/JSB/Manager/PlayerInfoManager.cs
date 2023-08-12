using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
    [SerializeField] private List<Transform> lstRoadRoute;
    public List<Transform> LstRoadRoute => lstRoadRoute;
    [SerializeField] public RiverPioneer playerUnit;
    [SerializeField] private MoneyUI moneyUI;
    [SerializeField] private Slider healthSlider;
    //[SerializeField] private HealthUI healthUI;
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
        //healthUI.InitHealth(playerMaxHealth);
        playerUnit.PlayerInit();
        healthSlider.maxValue = playerMaxHealth;
        healthSlider.value = playerMaxHealth;
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

        healthSlider.value = health;
        //healthUI.UpdateHealthInfo(health, playerMaxHealth);
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
