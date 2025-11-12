using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;

public class CityScript : MonoBehaviour
{
    public ClickScript clickScript;
    public SpriteRenderer cityImage;

    public List<Sprite> cityImages; // 0 é neutro  ,  de 1 a 10 é referente as imagens de ia   , de 11 a 20 referente as imagens de humanos

    

    void Start()
    {
        
    }

    void Update()
    {

        switch (clickScript.alignment)
        {
            case 0:
                cityImage.sprite = cityImages[0];
                break;

            case 1:
                cityImage.sprite = cityImages[1];
                break;

            case -1:
                cityImage.sprite = cityImages[2];
                break;



        }
    }
}
