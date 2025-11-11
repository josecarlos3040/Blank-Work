using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class MoneyScript : MonoBehaviour
{
    [HideInInspector] public int money = 0;

    [Header ("Human Config")]
    public int human = 0;
    public float basePriceHuman = 10;
    public float priceHuman;  //preco pra compra
    public float buyHumanScale = 1.25f;
    public float humanValue; // valor q geram
    public float humanCooldown;
    

    [Header ("IA Config")]
    public int ia = 0;
    public bool turnOn;
    public float priceIA;
    public float basePriceIa = 5;
    public int buyIAScale = 2;
    public float iaValue;
    public float iaCooldown;
    public float iaTime;
    public float iaTimeCooldown;
    public bool iaTimeIsRunning = false;
    public GameObject popUpIa;
    public bool firstTime;
    

    bool humanRunning = false;
    public bool iaRunning = false;

    void Start()
    {
        firstTime = false;
        turnOn = false;
        popUpIa.SetActive(false);

        UpdatePriceIa();
        UpdatePriceHuman();
    }
    void Update()
    {
        if (human > 0 && !humanRunning)
        {
            StartCoroutine(HumanWork());
        }
        if (ia > 0 && !iaRunning)
        {
            if(turnOn == true && iaTimeIsRunning == true)
            {
                StartCoroutine(IAWork());
            }
            if (turnOn == false && iaTimeIsRunning == false && firstTime == false)
            {
                turnOn = true;
                iaTimeIsRunning = true;
                firstTime = true;

            }
            else if(turnOn == false && iaTimeIsRunning == false)
            {
                return;
            }
            

        }

        if(iaTimeIsRunning == true)
        {
            
            iaTime -= Time.deltaTime;

            if(iaTime <= 0)
            {
                popUpIa.SetActive(true);
            }
        }

    }

    public void UpdatePriceIa()
    {
        priceIA = basePriceIa + (ia * buyIAScale);
    }

    public void UpdatePriceHuman()
    {
        priceHuman = (int)basePriceHuman + (int)(human * buyHumanScale);
    }
    IEnumerator HumanWork()
    {
        humanRunning = true;
        money += (int)humanValue * (int)human;
        yield return new WaitForSeconds(humanCooldown);
        humanRunning = false;
    }

    IEnumerator IAWork()
    {
        if(turnOn == true)
        {
            iaRunning = true;
            yield return new WaitForSeconds(iaCooldown);

            if (turnOn == false)
            {
                iaRunning = false;
                yield break;
            }
            iaRunning = false;
            money += (int)iaValue * (int)ia;

            if (iaTime <= 0)
            {
                iaTime = iaTimeCooldown;
                money = 0;
                iaTimeIsRunning = false;
                iaRunning = true;
            }
        }

    }

}
