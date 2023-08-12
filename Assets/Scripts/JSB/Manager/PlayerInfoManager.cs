using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
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
    [SerializeField] private TextMeshProUGUI progressText;
    private int health;
    
    private int money;

    // For ProgressUI
    private int progressPercent;
    private float distancePercentUnit;
    [SerializeField] private string defaultText;
    private int pointMinCount = 3;
    private string pointString = "...";

    private void Awake()
    {
        progressPercent = 0;
        instance = this;
        DontDestroyOnLoad(this.gameObject);
    }

    private void Start()
    {
        //healthUI.InitHealth(playerMaxHealth);
        playerUnit.PlayerInit();
        healthSlider.maxValue = playerMaxHealth;
        healthSlider.value = playerMaxHealth;
        CaculateDistanceUnit();
    }

    private void CaculateDistanceUnit()
    {
        float distance = 0f;
        distance += Vector3.Distance(lstRoadRoute[0].position, playerUnit.transform.position);
        for(int i = 0; i < lstRoadRoute.Count - 1; ++i)
        {
            distance += Vector3.Distance(lstRoadRoute[i].position, lstRoadRoute[i + 1].position);
        }
        distancePercentUnit = distance / 100f;
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

    private void GameProgressUpdate()
    {
        string text = defaultText.Substring(0, defaultText.Length - pointMinCount);
        progressText.text = $"{text} {progressPercent.ToString()}%";
        progressText.text += pointString.Substring(0, 3 - pointMinCount);

    }
    private void Update()
    {
        
    }
}
