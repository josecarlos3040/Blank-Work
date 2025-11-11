using UnityEngine;
using UnityEngine.InputSystem;

public class CameraScript : MonoBehaviour
{
    [Header("Configurações")]
    public float maxRotation = 30f;
    public float smoothSpeed = 5f;

    public float borderSize; //"Tamanho da borda da tela onde o mouse ativa o movimento"

    private float targetRotationY = 0f;
    private float currentRotationY = 0f;


    public ClickScript clickScript;

    void Update()
    {
        if (Mouse.current == null) return;

        if(clickScript.pcHudIsOn == true) return;

        Vector2 mousePos = Mouse.current.position.ReadValue();
        if (mousePos.x < borderSize)
        {
            targetRotationY =- maxRotation;
        }
        else if (mousePos.x < borderSize)
        {
            targetRotationY =- maxRotation;
        }
        else
        {
            targetRotationY = 0f;
        }
        currentRotationY = Mathf.Lerp(currentRotationY, targetRotationY, Time.deltaTime * smoothSpeed);

        transform.localRotation = Quaternion.Euler(0f, currentRotationY, 0f);
    }
}