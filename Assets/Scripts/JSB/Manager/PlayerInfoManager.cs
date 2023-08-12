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

    [SerializeField] private int money;

    // For ProgressUI
    [SerializeField] private string defaultText;
    [SerializeField] private float textUpdateTime;

    [SerializeField] private GameObject endingUI;

    private int progressPercent;
    public int ProgressPrecent => progressPercent;
    private float distancePercentUnit;
    private float pivotPercentUpValue;
    private int pointMinPivot = 3;
    private int pointMinCount;
    private string pointString = "...";
    private float textUpdateTimer = 0f;

    private void Awake()
    {
        pointMinCount = pointMinPivot;
        progressPercent = 0;
        pivotPercentUpValue = 0;
        instance = this;
        DontDestroyOnLoad(this.gameObject);
    }

    private void Start()
    {

        SoundManager.Instance.PlayInGameSound();

        //healthUI.InitHealth(playerMaxHealth);
        playerUnit.PlayerInit();
        healthSlider.maxValue = playerMaxHealth;
        healthSlider.value = playerMaxHealth;
        CaculateDistanceUnit();
    }

    private void CaculateDistanceUnit()
    {
        float distance = 0f;
        distance += Vector2.Distance(lstRoadRoute[0].position, playerUnit.transform.position);
        for (int i = 0; i < lstRoadRoute.Count - 1; ++i)
        {
            distance += Vector2.Distance(lstRoadRoute[i].position, lstRoadRoute[i + 1].position);
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

    private void ProgressUpdate()
    {
        if (playerUnit.PlayerMovedValue >= pivotPercentUpValue)
        {
            pivotPercentUpValue += distancePercentUnit;
            progressPercent = (int)
            ++progressPercent;
        }
    }
    private void GameProgressUpdate()
    {
        Debug.Log($"PlayerMoved Value : {playerUnit.PlayerMovedValue}");
        --pointMinCount;
        if (0 > pointMinCount)
        {
            pointMinCount = pointMinPivot;
        }
        progressText.text = $"{defaultText} {progressPercent.ToString()}%";
        progressText.text += pointString.Substring(0, 3 - pointMinCount);
        if (progressPercent >= 97)
            endingUI.SetActive(true);
    }
    private void Update()
    {
        if (textUpdateTime <= textUpdateTimer)
        {
            GameProgressUpdate();
            textUpdateTimer = 0f;
        }
        else
            textUpdateTimer += Time.deltaTime;
        ProgressUpdate();
    }
}
