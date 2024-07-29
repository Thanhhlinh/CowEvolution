using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeColorCow : MonoBehaviour
{
    public static ChangeColorCow Instance { get; private set; }
    public GameObject changeColorUI;
    public Color[] colorCow;
    public Color[] changeColor;
    public int colorCowIndex =0;

    public RectTransform[] cowImage;  
 

    public float zoomSpeed = 0.1f;
    public float maxZoomIn = 2.0f;
    public float maxZoomOut = 0.5f;
    private void Awake()
    {
        if(Instance != null && Instance == this)
        {
            return;
        }
        else
        {
            Instance = this;
        }
        
    }
    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < colorCow.Length; i++)
        {
            colorCow[i] = changeColor[0];
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OpenClose_ChangeColor()
    {
        if (AudioManager.Instance.soundEffectToggle.isOn)
        {
            AudioManager.Instance.PlayCloseSound();
        }
        
        changeColorUI.SetActive(!changeColorUI.activeSelf);
    }

    public void ChangeColorWhite()
    {
        colorCow[colorCowIndex] = changeColor[0];
    }
    public void ChangeColorRed()
    {
        colorCow[colorCowIndex] = changeColor[1];
    }
    public void ChangeColorGreen()
    {
        colorCow[colorCowIndex] = changeColor[2];
    }
    public void ChangeColorBlack()
    {
        colorCow[colorCowIndex] = changeColor[3];
    }
    public void ChangeColorBlue()
    {
        colorCow[colorCowIndex] = changeColor[4];
    }

    // Hàm để zoom vào
    public void ZoomIn()
    {
        if (cowImage[colorCowIndex].localScale.x < maxZoomIn)
        {
            cowImage[colorCowIndex].localScale += new Vector3(zoomSpeed, zoomSpeed, zoomSpeed);
        }
    }

    // Hàm để zoom ra
    public void ZoomOut()
    {
        if (cowImage[colorCowIndex].localScale.x > maxZoomOut)
        {
            cowImage[colorCowIndex].localScale -= new Vector3(zoomSpeed, zoomSpeed, zoomSpeed);
        }
    }
}
