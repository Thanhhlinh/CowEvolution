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
    public Button buyCrateBTN, buyBerryDeliveryBTN, buyMagnetBTN, buyEvolutionBar;
    public int priceUpgradeCrate = 300, priceUpgradeBerry = 400, priceUpgradeMagnet = 500, priceEvolutionBar = 600;

    private GameManager gameManager;
    private AudioManager audioManager;

    private IUpgradeStrategy crateUpgradeStrategy;
    private IUpgradeStrategy berryDeliveryUpgradeStrategy;
    private IUpgradeStrategy magnetUpgradeStrategy;
    private IUpgradeStrategy evolutionBarUpgradeStrategy;

    private void Start()
    {
        gameManager = GameManager.Instance;
        audioManager = AudioManager.Instance;
        crateUpgradeStrategy = new CrateUpgradeStrategy(this);
        berryDeliveryUpgradeStrategy = new BerryDeliveryUpgradeStrategy(this);
        magnetUpgradeStrategy = new MagnetUpgradeStrategy(this);
        evolutionBarUpgradeStrategy = new EvolutionBarUpgradeStrategy(this);
    }
    void Update()
    {
        crateUpgradeStrategy.UpdateUI();
        berryDeliveryUpgradeStrategy.UpdateUI();
        magnetUpgradeStrategy.UpdateUI();
        evolutionBarUpgradeStrategy.UpdateUI();

        if (gameManager.boughtMagnet)
        {
            magnetUI.SetActive(true);
            sliderEvolutionBarUI.SetActive(true);
        }
        if (gameManager.boughtEvolutionBar)
        {
            sliderEvolutionBarUI.SetActive(true);
        }
        CheckLevels();
        

    }
    public void OpenClose_Upgrade()
    {
        if (audioManager.soundEffectToggle.isOn)
        {
            audioManager.PlayCloseSound();
        }
        upgradeUI.SetActive(!upgradeUI.activeSelf);
    }

    public void BuyCrate()
    {
        crateUpgradeStrategy.BuyUpgrade();   
    }

    public void BuyBerryDelivery()
    {
        berryDeliveryUpgradeStrategy.BuyUpgrade();   
    }

    public void BuyMagnet()
    {
        magnetUpgradeStrategy.BuyUpgrade(); 
    }

    public void BuyEvolutionBar()
    {
        evolutionBarUpgradeStrategy.BuyUpgrade(); 
    }


    public void CheckLevels()
    {
        crateUpgradeStrategy.CheckLevel();
        berryDeliveryUpgradeStrategy.CheckLevel();
        magnetUpgradeStrategy.CheckLevel();
        evolutionBarUpgradeStrategy.CheckLevel();
    }

}

