using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Contents : MonoBehaviour
{
    public Image[] cowImg;
    public TextMeshProUGUI[] cowName;
    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < cowImg.Length; i++)
        {
            cowImg[i].sprite = GameManager.Instance.cow_Sprites[i];
            cowName[i].text = GameManager.Instance.cow_Names[i];
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
