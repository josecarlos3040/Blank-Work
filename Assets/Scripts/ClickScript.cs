using UnityEngine;

public class ClickScript : MonoBehaviour
{
    public MoneyScript moneyScript;
    public HudScript hudScript;

    public GameObject pcHud;
    public GameObject stockMarketButton;
    public GameObject stockMarket;
    public bool stockMarketFT = false;


    public bool pcHudIsOn;
    public bool turnOnCooldownIsOn;

    public int clickValue = 1;

    public float alignment = 0; //positivo é humano negativo é ia

    [Header("Upgrades")]
    public GameObject upgradeMouseButton;
    public int mousePrice = 50;
    public bool upgradeMouse = false;

    public GameObject upgradeCLTHuman;
    public int upgradeCLTHumanPrice = 50;
    public bool upgradeCLTHumanIsOn = false;

    void Start()
    {
        stockMarket.SetActive(false);
        pcHud.SetActive(false);  
        pcHudIsOn = false;
        turnOnCooldownIsOn = false;
    }

    void Update()
    {
        if(turnOnCooldownIsOn == true)
        {
            hudScript.turnOnCooldown -= Time.deltaTime;
        }

        if(moneyScript.money > 100 && stockMarketFT == false)
        {
            stockMarketButton.SetActive(true);
        }
    }

    public void Click()
    {
        moneyScript.money += clickValue;
    }


    public void ContratarHumano()
    {
        if (moneyScript.money >= moneyScript.priceHuman)
        {
            if(alignment <= 10)
            {
                alignment += 1;
            }

            moneyScript.money -= (int)moneyScript.priceHuman;
            moneyScript.human += 1;
            moneyScript.UpdatePriceHuman();
            

        }
    }

    public void ContratarIA()
    {
        if(moneyScript.money >= moneyScript.priceIA)
        {
            if (alignment >= -10)
            {
                alignment += -1;
            }
            moneyScript.money -= (int)moneyScript.priceIA;
            moneyScript.ia += 1;
            moneyScript.UpdatePriceIa();
            

        }
    }

    public void ClosePopUpIA()
    {
        moneyScript.popUpIa.SetActive(false);
        moneyScript.iaTimeIsRunning = true;
        moneyScript.iaRunning = false;
    }

    public void TurnOffIA()
    {
        moneyScript.turnOn = false;
        moneyScript.iaTimeIsRunning = false;
        moneyScript.iaTime = moneyScript.iaTimeCooldown;

        turnOnCooldownIsOn = true;
    }

    public void TurnOnIA()
    {
        moneyScript.turnOn = true;
        moneyScript.iaTimeIsRunning = true;
        moneyScript.iaTime = moneyScript.iaTimeCooldown;
        hudScript.turnOnCooldown = hudScript.turnOnCooldownMax;
        turnOnCooldownIsOn = false;
    }

    public void ComprarMouse()
    {
        if(moneyScript.money >= mousePrice && upgradeMouse == false)
        {
            upgradeMouse = true;
            clickValue += 4;
            moneyScript.money -= mousePrice;
            upgradeMouseButton.SetActive(false);
        }
    }

    public void ComprarDireitosTrabalhistas()
    {
        if (moneyScript.money >= upgradeCLTHumanPrice && upgradeCLTHumanIsOn == false)
        {
            upgradeCLTHumanIsOn = true;
            moneyScript.humanValue += 8;
            moneyScript.money -= upgradeCLTHumanPrice;
            upgradeCLTHuman.SetActive(false);
            hudScript.firstCLTUpgradeVerify = true;
        }
    }

    public void OpenStockMarketWindow()
    {
        stockMarket.SetActive(true);
    }

    public void CloseStockMarketWindow()
    {
        stockMarket.SetActive(false);
    }



    public void ShowHudPc()
    {
        pcHud.SetActive(true);
        pcHudIsOn = true;
    }

    public void HideHudPc()
    {
        pcHud.SetActive(false);
        pcHudIsOn = false;
    }




}
