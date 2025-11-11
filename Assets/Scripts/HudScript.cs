using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HudScript : MonoBehaviour
{
    public MoneyScript moneyScript;
    public ClickScript clickScript;

    public TextMeshProUGUI moneyHud;
    public TextMeshProUGUI moneyHudStock;

    public TextMeshProUGUI humanosQyd;
    public TextMeshProUGUI iaQyd;
    public TextMeshProUGUI humanosQydStock;
    public TextMeshProUGUI iaQydStock;


    public Slider alignmentSlider;
    public Slider sliderIaTime;
    public GameObject sliderIaTimeGameObject;

    public GameObject CLTUpgrade;
    public bool firstCLTUpgradeVerify = false;
    

    [Header("Turn On/Off Ia")]
    public GameObject turnOnButton;
    public Button turnOnBut;
    public float turnOnCooldown;
    public float turnOnCooldownMax;

    public Slider turnOnCooldownSlider;
    public GameObject turnOnCooldownGO;



    public GameObject turnOffButton;
    public bool setFalseOnButton = false;


    [Header("Hired Prices")]
    public TextMeshProUGUI buyHuman;
    public TextMeshProUGUI buyIa;

    [Header("Upgrade Prices")]
    public TextMeshProUGUI mousePrice;
    public TextMeshProUGUI CLTPrice;

    


    void Start()
    {
        sliderIaTimeGameObject.SetActive(false);
        turnOffButton.SetActive(false);
        turnOnButton.SetActive(false);

        turnOnCooldown = turnOnCooldownMax;
        turnOnCooldownGO.SetActive(false);

        CLTUpgrade.SetActive(false);
    }



    void Update()
    {
        if (moneyScript == null)
        {
            return;
        }
        moneyHud.text = " R$" + moneyScript.money.ToString() + ",00" ;
        moneyHudStock.text = " R$" + moneyScript.money.ToString() + ",00";

        humanosQyd.text = "Humanos: " + moneyScript.human;
        humanosQydStock.text = "Humanos: " + moneyScript.human;
        iaQyd.text = "Ia: " + moneyScript.ia;
        iaQydStock.text = "Ia: " + moneyScript.ia;

        buyHuman.text = "Humano Valor R$" + moneyScript.priceHuman + ",00";
        buyIa.text = "Ia Valor R$" + moneyScript.priceIA + ",00";

        mousePrice.text = "Comprar mouse valor R$" + clickScript.mousePrice +",00";
        CLTPrice.text = "Comprar Direitos para humanos valor R$" + clickScript.upgradeCLTHumanPrice + ",00";

        alignmentSlider.value = clickScript.alignment;

        turnOnCooldownSlider.value = turnOnCooldown;

        if(moneyScript.ia > 0)
        {
            sliderIaTimeGameObject.SetActive(true);
        }
        sliderIaTime.value = moneyScript.iaTime;

        if(moneyScript.human > 0 && firstCLTUpgradeVerify == false)
        {
            CLTUpgrade.SetActive(true);
        }



        if(moneyScript.turnOn == true)
        {
            turnOnButton.SetActive(false);
            turnOffButton.SetActive(true);
            setFalseOnButton = true;


        }
        else if (moneyScript.turnOn == false && setFalseOnButton == true)
        {
            turnOffButton.SetActive(false);
            turnOnButton.SetActive(true);
            if(turnOnCooldown <= 0)
            {
                turnOnBut.interactable = true;
                turnOnCooldownGO.SetActive(false);
            }
            else
            {
                turnOnBut.interactable = false;
                turnOnCooldownGO.SetActive(true);
            }
        }
    }
}
