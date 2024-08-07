using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Contents : MonoBehaviour
{
    public Image[] cowImg;
    public TextMeshProUGUI[] cowName;
    private GameManager gameManager;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameManager.Instance;
        for(int i = 0; i < cowImg.Length; i++)
        {
            cowImg[i].sprite = gameManager.cow_Sprites[i];
            cowName[i].text = gameManager.cow_Names[i];
        }
    } 
}
