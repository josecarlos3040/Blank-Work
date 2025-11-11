using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class StockMarketScript : MonoBehaviour
{
    public MoneyScript moneyScript;
    public ClickScript clickScript;

    public TextMeshProUGUI textPriceStock1;

    [Header("StockMarket Prices")]
    public int variationMin;
    public int variationMax;
    public int cooldownTime;

    public bool restartMarket = true;

    public int iaPriceStock1;

    void Update()
    {
        if(restartMarket == true)
        {
            StartCoroutine(VariationPrice());
        }

        textPriceStock1.text = "Mercado 1 preço: R$" +iaPriceStock1.ToString() + ",00";
    }

    public void BuyIaStockMarket1x1()
    {
        if (moneyScript.money >= iaPriceStock1)
        {
            if (clickScript.alignment >= -10)
            {
                clickScript.alignment += -1;
            }
            moneyScript.money -= iaPriceStock1;
            moneyScript.ia += 1;
            moneyScript.UpdatePriceIa();
        }
    }    

    public void SellIaStockMarket1x1()
    {
        if (moneyScript.ia >= 1)
        {
            if (clickScript.alignment >= -10)
            {
                clickScript.alignment += -1;
            }
            moneyScript.money += iaPriceStock1;
            moneyScript.ia -= 1;
            moneyScript.UpdatePriceIa();
        }
    }

    IEnumerator VariationPrice()
    {
        restartMarket = false;
        iaPriceStock1 = Random.Range(variationMin, variationMax+1);
        yield return new WaitForSeconds (cooldownTime);
        restartMarket = true;
    }

}
