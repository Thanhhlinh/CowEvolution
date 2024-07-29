using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Upgrades : MonoBehaviour
{
    public GameObject upgradeUI;
    public GameObject magnetUI;
    public GameObject sliderEvolutionBarUI;
    public Sprite diamondsSprite;
    public Button buyCrateBTN,buyBerryDeliveryBTN,buyMagnetBTN , buyEvolutionBar;
    private int priceUpgradeCrate =300, priceUpgradeBerry = 400, priceUpgradeMagnet = 500 , priceEvolutionBar = 600;
    
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        Texts.Instance.ChangeBuyUpgradeCrateText(priceUpgradeCrate);
        Texts.Instance.ChangeBuyUpgradeBerryDeliveryText(priceUpgradeBerry);
        Texts.Instance.ChangeBuyUpgradeMagnetText(priceUpgradeMagnet);
        Texts.Instance.ChangeBuyEvolutionBarText(priceEvolutionBar);
        if (GameManager.Instance.boughtMagnet)
        {
            magnetUI.SetActive(true);
            sliderEvolutionBarUI.SetActive(true);
        }
        if (GameManager.Instance.boughtEvolutionBar)
        {    
            sliderEvolutionBarUI.SetActive(true);
        }
        CheckLevel();
        
    }
    public void OpenClose_Upgrade()
    {
        if (AudioManager.Instance.soundEffectToggle.isOn)
        {
            AudioManager.Instance.PlayCloseSound();
        }
        upgradeUI.SetActive(!upgradeUI.activeSelf);
    }

    public void BuyCrate()
    {
        if (GameManager.Instance.levelCrate >= 3)
        {
            GameManager.Instance.SpendDiamonds(-priceUpgradeCrate);
            GameManager.Instance.StartCrateSpawn();
            GameManager.Instance.repeatInterval--;
            GameManager.Instance.levelCrate++;

        }
        else
        {
            GameManager.Instance.SpendCoins(-priceUpgradeCrate);
            GameManager.Instance.StartCrateSpawn();
            GameManager.Instance.repeatInterval--;
            GameManager.Instance.levelCrate++;
        }
        
    }

    public void BuyBerryDelivery()
    {
        if (GameManager.Instance.levelBerry >= 3)
        {
            GameManager.Instance.SpendDiamonds(-priceUpgradeBerry);
            GameManager.Instance.StartBerryDeliverySpawn();
            GameManager.Instance.timerSpawnTreeBerry--;
            GameManager.Instance.levelBerry++;

        }
        else
        {
            GameManager.Instance.SpendCoins(-priceUpgradeBerry);
            GameManager.Instance.StartBerryDeliverySpawn();
            GameManager.Instance.timerSpawnTreeBerry--;
            GameManager.Instance.levelBerry++;
        }
      
    }

    public void BuyMagnet()
    {
        if(GameManager.Instance.levelMagnet >=3)
        {
            GameManager.Instance.SpendDiamonds(-priceUpgradeMagnet);    
            GameManager.Instance.isAutoEvolveEnabled = true;
            GameManager.Instance.evolveInterval--;
            magnetUI.SetActive(true);
            GameManager.Instance.levelMagnet++;
            
        }
        else
        {
            GameManager.Instance.StartMagnet();
            GameManager.Instance.SpendCoins(-priceUpgradeMagnet);
            GameManager.Instance.isAutoEvolveEnabled = true;
            GameManager.Instance.evolveInterval--;
            magnetUI.SetActive(true);
            GameManager.Instance.levelMagnet++;
            
        }
        
    }

    public void BuyEvolutionBar()
    {
        if (GameManager.Instance.levelEvolutionBar >= 3)
        {
            GameManager.Instance.SpendDiamonds(-priceEvolutionBar);
            GameManager.Instance.StartEvolutionBarSpawn();
            GameManager.Instance.maxEvolutionBar--;
            sliderEvolutionBarUI.SetActive(true);
            GameManager.Instance.levelEvolutionBar++;

        }
        else
        {
            GameManager.Instance.SpendCoins(-priceUpgradeMagnet);
            GameManager.Instance.StartEvolutionBarSpawn();
            GameManager.Instance.maxEvolutionBar--;
            sliderEvolutionBarUI.SetActive(true);
            GameManager.Instance.levelEvolutionBar++;

        }

    }


    public void CheckLevel()
    {
        if (GameManager.Instance.levelMagnet >= 3 && GameManager.Instance.levelMagnet <5)
        {
            priceUpgradeMagnet = GameManager.Instance.levelMagnet;
            buyMagnetBTN.gameObject.transform.Find("Image").GetComponent<Image>().sprite = diamondsSprite;
            buyMagnetBTN.transform.parent.transform.Find("Time").GetComponent<TextMeshProUGUI>().text = GameManager.Instance.evolveInterval + "s->" + (GameManager.Instance.evolveInterval - 1) + "s";
            if (GameManager.Instance.diamonds >= priceUpgradeMagnet)
            {
                buyMagnetBTN.interactable = true;
            }
            else
            {
                buyMagnetBTN.interactable = false;
            }
        }
        else if (GameManager.Instance.levelMagnet >= 5)
        {
            buyMagnetBTN.interactable=false;
        }
        else
        {
            buyMagnetBTN.transform.parent.transform.Find("Time").GetComponent<TextMeshProUGUI>().text = GameManager.Instance.evolveInterval + "s->" + (GameManager.Instance.evolveInterval-1) + "s";
            if (GameManager.Instance.coins >= priceUpgradeMagnet)
            {
                buyMagnetBTN.interactable = true;
            }
            else
            {
                buyMagnetBTN.interactable = false;
            }
        }


        if (GameManager.Instance.levelBerry >= 3 && GameManager.Instance.levelBerry < 5)
        {
            priceUpgradeBerry = GameManager.Instance.levelBerry;
            buyBerryDeliveryBTN.gameObject.transform.Find("Image").GetComponent<Image>().sprite = diamondsSprite;
            buyBerryDeliveryBTN.transform.parent.transform.Find("Time").GetComponent<TextMeshProUGUI>().text = GameManager.Instance.timerSpawnTreeBerry + "s->" + (GameManager.Instance.timerSpawnTreeBerry - 1) + "s";
            if (GameManager.Instance.diamonds >= priceUpgradeBerry)
            {
                buyBerryDeliveryBTN.interactable = true;
            }
            else
            {
                buyBerryDeliveryBTN.interactable = false;
            }
        }
        else if (GameManager.Instance.levelBerry >= 5)
        {
            buyMagnetBTN.interactable = false;
        }
        else
        {
            buyBerryDeliveryBTN.transform.parent.transform.Find("Time").GetComponent<TextMeshProUGUI>().text = GameManager.Instance.timerSpawnTreeBerry + "s->" + (GameManager.Instance.timerSpawnTreeBerry - 1) + "s";
            if (GameManager.Instance.coins >= priceUpgradeBerry)
            {
                buyBerryDeliveryBTN.interactable = true;
            }
            else
            {
                buyBerryDeliveryBTN.interactable = false;
            }
        }


        if (GameManager.Instance.levelCrate >= 3 && GameManager.Instance.levelCrate < 5)
        {
            priceUpgradeCrate = GameManager.Instance.levelCrate;
            buyCrateBTN.gameObject.transform.Find("Image").GetComponent<Image>().sprite = diamondsSprite;
            buyCrateBTN.transform.parent.transform.Find("Time").GetComponent<TextMeshProUGUI>().text = GameManager.Instance.repeatInterval + "s->" + (GameManager.Instance.repeatInterval - 1) + "s";
            if (GameManager.Instance.diamonds >= priceUpgradeCrate)
            {
                buyCrateBTN.interactable = true;
            }
            else
            {
                buyCrateBTN.interactable = false;
            }
        }
        else if (GameManager.Instance.levelCrate >= 5)
        {
            buyMagnetBTN.interactable = false;
        }
        else
        {
            buyCrateBTN.transform.parent.transform.Find("Time").GetComponent<TextMeshProUGUI>().text = GameManager.Instance.repeatInterval + "s->" + (GameManager.Instance.repeatInterval - 1) + "s";
            if (GameManager.Instance.coins >= priceUpgradeCrate)
            {
                buyCrateBTN.interactable = true;
            }
            else
            {
                buyCrateBTN.interactable = false;
            }
        }


        if (GameManager.Instance.levelEvolutionBar >= 3 && GameManager.Instance.levelEvolutionBar < 5)
        {
            priceEvolutionBar = GameManager.Instance.levelEvolutionBar;
            buyEvolutionBar.gameObject.transform.Find("Image").GetComponent<Image>().sprite = diamondsSprite;
            buyEvolutionBar.transform.parent.transform.Find("Time").GetComponent<TextMeshProUGUI>().text = GameManager.Instance.maxEvolutionBar + "s->" + (GameManager.Instance.maxEvolutionBar - 1) + "s";
            if (GameManager.Instance.diamonds >= priceEvolutionBar)
            {
                buyEvolutionBar.interactable = true;
            }
            else
            {
                buyEvolutionBar.interactable = false;
            }
        }
        else if (GameManager.Instance.levelEvolutionBar >= 5)
        {
            buyEvolutionBar.interactable = false;
        }
        else
        {
            buyEvolutionBar.transform.parent.transform.Find("Time").GetComponent<TextMeshProUGUI>().text = GameManager.Instance.maxEvolutionBar + "s->" + (GameManager.Instance.maxEvolutionBar - 1) + "s";
            if (GameManager.Instance.coins >= priceEvolutionBar)
            {
                buyEvolutionBar.interactable = true;
            }
            else
            {
                buyEvolutionBar.interactable = false;
            }
        }
    }
}
