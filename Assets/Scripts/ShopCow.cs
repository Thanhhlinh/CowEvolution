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
    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < priceCow.Length; i++)
        {
            Texts.Instance.ChangeBuyCowCoinsText(i,priceCow[i]);
        }
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < viewBuyCows.Length; i++)
        {
            viewBuyCows[i].SetActive(GameManager.Instance.highest_Tier >= i);
        }
    }
    public void OpenClose_ShopCow()
    {
        if (AudioManager.Instance.soundEffectToggle.isOn)
        {
            AudioManager.Instance.PlayCloseSound();
        }
        shopCowUI.SetActive(!shopCowUI.activeSelf);
    }

    public void BuyCow01()
    {
        if (GameManager.Instance.coins >= priceCow[0])
        {
            GameManager.Instance.SpendCoins(-priceCow[0]);
            GameManager.Instance.ShopSpawnCow(prefabCow[0]);
        }
        else
        {
            buyCow[0].interactable = false;
        }
    }

    public void BuyCow02()
    {
        if (GameManager.Instance.coins >= priceCow[1])
        {
            GameManager.Instance.SpendCoins(-priceCow[1]);
            GameManager.Instance.ShopSpawnCow(prefabCow[1]);
        }
        else
        {
            buyCow[1].interactable = false;
        }
    }

    public void BuyCow03()
    {
        if (GameManager.Instance.coins >= priceCow[2])
        {
            GameManager.Instance.SpendCoins(-priceCow[2]);
            GameManager.Instance.ShopSpawnCow(prefabCow[2]);
        }
        else
        {
            buyCow[2].interactable = false;
        }
    }

    public void BuyCow04()
    {
        if (GameManager.Instance.coins >= priceCow[3])
        {
            GameManager.Instance.SpendCoins(-priceCow[3]);
            GameManager.Instance.ShopSpawnCow(prefabCow[3]);
        }
        else
        {
            buyCow[3].interactable = false;
        }
    }

    public void BuyCow05()
    {
        if (GameManager.Instance.coins >= priceCow[4])
        {
            GameManager.Instance.SpendCoins(-priceCow[4]);
            GameManager.Instance.ShopSpawnCow(prefabCow[4]);
        }
        else
        {
            buyCow[4].interactable = false;
        }
    }
    public void BuyCow06()
    {
        if (GameManager.Instance.coins >= priceCow[5])
        {
            GameManager.Instance.SpendCoins(-priceCow[5]);
            GameManager.Instance.ShopSpawnCow(prefabCow[5]);
        }
        else
        {
            buyCow[5].interactable = false;
        }
    }
    public void BuyCow07()
    {
        if (GameManager.Instance.coins >= priceCow[6])
        {
            GameManager.Instance.SpendCoins(-priceCow[6]);
            GameManager.Instance.ShopSpawnCow(prefabCow[6]);
        }
        else
        {
            buyCow[6].interactable = false;
        }
    }

    public void BuyCow08()
    {
        if (GameManager.Instance.coins >= priceCow[7])
        {
            GameManager.Instance.SpendCoins(-priceCow[7]);
            GameManager.Instance.ShopSpawnCow(prefabCow[7]);
        }
        else
        {
            buyCow[7].interactable = false;
        }
    }

    public void BuyCow09()
    {
        if (GameManager.Instance.coins >= priceCow[8])
        {
            GameManager.Instance.SpendCoins(-priceCow[8]);
            GameManager.Instance.ShopSpawnCow(prefabCow[8]);
        }
        else
        {
            buyCow[8].interactable = false;
        }
    }

    public void BuyCow10()
    {
        if (GameManager.Instance.coins >= priceCow[9])
        {
            GameManager.Instance.SpendCoins(-priceCow[9]);
            GameManager.Instance.ShopSpawnCow(prefabCow[9]);
        }
        else
        {
            buyCow[9].interactable = false;
        }
    }

    public void BuyCow11()
    {
        if (GameManager.Instance.coins >= priceCow[10])
        {
            GameManager.Instance.SpendCoins(-priceCow[10]);
            GameManager.Instance.ShopSpawnCow(prefabCow[10]);
        }
        else
        {
            buyCow[10].interactable = false;
        }
    }

    public void BuyCow12()
    {
        if (GameManager.Instance.coins >= priceCow[11])
        {
            GameManager.Instance.SpendCoins(-priceCow[11]);
            GameManager.Instance.ShopSpawnCow(prefabCow[11]);
        }
        else
        {
            buyCow[11].interactable = false;
        }
    }

    public void BuyCow13()
    {
        if (GameManager.Instance.coins >= priceCow[12])
        {
            GameManager.Instance.SpendCoins(-priceCow[12]);
            GameManager.Instance.ShopSpawnCow(prefabCow[12]);
        }
        else
        {
            buyCow[12].interactable = false;
        }
    }

    public void BuyCow14()
    {
        if (GameManager.Instance.coins >= priceCow[13])
        {
            GameManager.Instance.SpendCoins(-priceCow[13]);
            GameManager.Instance.ShopSpawnCow(prefabCow[13]);
        }
        else
        {
            buyCow[13].interactable = false;
        }
    }

    public void BuyCow15()
    {
        if (GameManager.Instance.coins >= priceCow[14])
        {
            GameManager.Instance.SpendCoins(-priceCow[14]);
            GameManager.Instance.ShopSpawnCow(prefabCow[14]);
        }
        else
        {
            buyCow[14].interactable = false;
        }
    }

    public void BuyCow16()
    {
        if (GameManager.Instance.coins >= priceCow[15])
        {
            GameManager.Instance.SpendCoins(-priceCow[15]);
            GameManager.Instance.ShopSpawnCow(prefabCow[15]);
        }
        else
        {
            buyCow[15].interactable = false;
        }
    }

    public void BuyCow17()
    {
        if (GameManager.Instance.coins >= priceCow[16])
        {
            GameManager.Instance.SpendCoins(-priceCow[16]);
            GameManager.Instance.ShopSpawnCow(prefabCow[16]);
        }
        else
        {
            buyCow[16].interactable = false;
        }
    }

    public void BuyCow18()
    {
        if (GameManager.Instance.coins >= priceCow[17])
        {
            GameManager.Instance.SpendCoins(-priceCow[17]);
            GameManager.Instance.ShopSpawnCow(prefabCow[17]);
        }
        else
        {
            buyCow[17].interactable = false;
        }
    }
}
