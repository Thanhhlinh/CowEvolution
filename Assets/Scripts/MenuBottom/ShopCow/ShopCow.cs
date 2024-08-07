using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopCow : MonoBehaviour
{
    public GameObject shopCowUI;
    public GameObject[] viewBuyCows;
    public Button[] buyCow;
    public GameObject[] prefabCow;
    public int[] priceCow;

    private GameManager gameManager;
    private Texts texts;
    private AudioManager audioManager;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameManager.Instance;
        audioManager = AudioManager.Instance;
        texts = Texts.Instance;
        for (int i = 0; i < priceCow.Length; i++)
        {
            texts.ChangeBuyCowCoinsText(i,priceCow[i]);
            int index = i; // Capture the index for the closure


            if (i < buyCow.Length) // Ensure the index is within the bounds of buyCow array
            {
                buyCow[i].onClick.AddListener(() => BuyCow(index));
            }
        }

    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < viewBuyCows.Length; i++)
        {
            viewBuyCows[i].SetActive(gameManager.highest_Tier >= i);
        }

    }
    public void OpenClose_ShopCow()
    {
        if (AudioManager.Instance != null && AudioManager.Instance.soundEffectToggle != null && AudioManager.Instance.soundEffectToggle.isOn)
        {
            AudioManager.Instance.PlayCloseSound();
        }
        shopCowUI.SetActive(!shopCowUI.activeSelf);
    }
    private void BuyCow(int index)
    {
        if (gameManager.coins >= priceCow[index])
        {
            gameManager.SpendCoins(-priceCow[index]);
            SpawnManager.Instance.ShopSpawnCow(prefabCow[index]);
        }
        else
        {
            buyCow[index].interactable = false;
        }
    }
    
}
