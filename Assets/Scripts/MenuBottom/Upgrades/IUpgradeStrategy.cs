using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public interface IUpgradeStrategy
{
    void BuyUpgrade();
    void UpdateUI();
    void CheckLevel();
}

public class CrateUpgradeStrategy : IUpgradeStrategy
{
    private readonly Upgrades upgrades;

    public CrateUpgradeStrategy(Upgrades upgrades)
    {
        this.upgrades = upgrades;
    }

    public void BuyUpgrade()
    {
        var gameManager = GameManager.Instance;
        int price = upgrades.priceUpgradeCrate;

        if (gameManager.levelCrate >= 3)
        {
            gameManager.SpendDiamonds(-price);
            gameManager.StartCrateSpawn();
            gameManager.repeatInterval--;
            gameManager.levelCrate++;
        }
        else
        {
            gameManager.SpendCoins(-price);
            gameManager.StartCrateSpawn();
            gameManager.repeatInterval--;
            gameManager.levelCrate++;
        }
    }

    public void UpdateUI()
    {
        Texts.Instance.ChangeBuyUpgradeCrateText(upgrades.priceUpgradeCrate);
    }

    public void CheckLevel()
    {
        var gameManager = GameManager.Instance;
        var button = upgrades.buyCrateBTN;

        if (gameManager.levelCrate >= 3 && gameManager.levelCrate < 5)
        {
            upgrades.priceUpgradeCrate = gameManager.levelCrate;
            button.transform.Find("Image").GetComponent<Image>().sprite = upgrades.diamondsSprite;
            button.transform.parent.Find("Time").GetComponent<TextMeshProUGUI>().text = $"{gameManager.repeatInterval}s-> {gameManager.repeatInterval - 1}s";

            button.interactable = gameManager.diamonds >= upgrades.priceUpgradeCrate;
        }
        else if (gameManager.levelCrate >= 5)
        {
            button.interactable = false;
        }
        else
        {
            button.transform.parent.Find("Time").GetComponent<TextMeshProUGUI>().text = $"{gameManager.repeatInterval}s-> {gameManager.repeatInterval - 1}s";
            button.interactable = gameManager.coins >= upgrades.priceUpgradeCrate;
        }
    }
}

public class BerryDeliveryUpgradeStrategy : IUpgradeStrategy
{
    private readonly Upgrades upgrades;

    public BerryDeliveryUpgradeStrategy(Upgrades upgrades)
    {
        this.upgrades = upgrades;
    }

    public void BuyUpgrade()
    {
        var gameManager = GameManager.Instance;
        int price = upgrades.priceUpgradeBerry;

        if (gameManager.levelBerry >= 3)
        {
            gameManager.SpendDiamonds(-price);
            gameManager.StartBerryDeliverySpawn();
            gameManager.timerSpawnTreeBerry--;
            gameManager.levelBerry++;
        }
        else
        {
            gameManager.SpendCoins(-price);
            gameManager.StartBerryDeliverySpawn();
            gameManager.timerSpawnTreeBerry--;
            gameManager.levelBerry++;
        }
    }

    public void UpdateUI()
    {
        Texts.Instance.ChangeBuyUpgradeBerryDeliveryText(upgrades.priceUpgradeBerry);
    }

    public void CheckLevel()
    {
        var gameManager = GameManager.Instance;
        var button = upgrades.buyBerryDeliveryBTN;

        if (gameManager.levelBerry >= 3 && gameManager.levelBerry < 5)
        {
            upgrades.priceUpgradeBerry = gameManager.levelBerry;
            button.transform.Find("Image").GetComponent<Image>().sprite = upgrades.diamondsSprite;
            button.transform.parent.Find("Time").GetComponent<TextMeshProUGUI>().text = $"{gameManager.timerSpawnTreeBerry}s-> {gameManager.timerSpawnTreeBerry - 1}s";

            button.interactable = gameManager.diamonds >= upgrades.priceUpgradeBerry;
        }
        else if (gameManager.levelBerry >= 5)
        {
            button.interactable = false;
        }
        else
        {
            button.transform.parent.Find("Time").GetComponent<TextMeshProUGUI>().text = $"{gameManager.timerSpawnTreeBerry}s-> {gameManager.timerSpawnTreeBerry - 1}s";
            button.interactable = gameManager.coins >= upgrades.priceUpgradeBerry;
        }
    }
}

public class MagnetUpgradeStrategy : IUpgradeStrategy
{
    private readonly Upgrades upgrades;

    public MagnetUpgradeStrategy(Upgrades upgrades)
    {
        this.upgrades = upgrades;
    }

    public void BuyUpgrade()
    {
        var gameManager = GameManager.Instance;
        int price = upgrades.priceUpgradeMagnet;

        if (gameManager.levelMagnet >= 3)
        {
            gameManager.SpendDiamonds(-price);
            gameManager.isAutoEvolveEnabled = true;
            gameManager.evolveInterval--;
            upgrades.magnetUI.SetActive(true);
            gameManager.levelMagnet++;
        }
        else
        {
            gameManager.SpendCoins(-price);
            gameManager.StartMagnet();
            gameManager.isAutoEvolveEnabled = true;
            gameManager.evolveInterval--;
            upgrades.magnetUI.SetActive(true);
            gameManager.levelMagnet++;
        }
    }

    public void UpdateUI()
    {
        Texts.Instance.ChangeBuyUpgradeMagnetText(upgrades.priceUpgradeMagnet);
    }

    public void CheckLevel()
    {
        var gameManager = GameManager.Instance;
        var button = upgrades.buyMagnetBTN;

        if (gameManager.levelMagnet >= 3 && gameManager.levelMagnet < 5)
        {
            upgrades.priceUpgradeMagnet = gameManager.levelMagnet;
            button.transform.Find("Image").GetComponent<Image>().sprite = upgrades.diamondsSprite;
            button.transform.parent.Find("Time").GetComponent<TextMeshProUGUI>().text = $"{gameManager.evolveInterval}s-> {gameManager.evolveInterval - 1}s";

            button.interactable = gameManager.diamonds >= upgrades.priceUpgradeMagnet;
        }
        else if (gameManager.levelMagnet >= 5)
        {
            button.interactable = false;
        }
        else
        {
            button.transform.parent.Find("Time").GetComponent<TextMeshProUGUI>().text = $"{gameManager.evolveInterval}s-> {gameManager.evolveInterval - 1}s";
            button.interactable = gameManager.coins >= upgrades.priceUpgradeMagnet;
        }
    }
}


public class EvolutionBarUpgradeStrategy : IUpgradeStrategy
{
    private readonly Upgrades upgrades;

    public EvolutionBarUpgradeStrategy(Upgrades upgrades)
    {
        this.upgrades = upgrades;
    }

    public void BuyUpgrade()
    {
        var gameManager = GameManager.Instance;
        int price = upgrades.priceEvolutionBar;

        if (gameManager.levelEvolutionBar >= 3)
        {
            gameManager.SpendDiamonds(-price);
            gameManager.StartEvolutionBarSpawn();
            gameManager.maxEvolutionBar--;
            upgrades.sliderEvolutionBarUI.SetActive(true);
            gameManager.levelEvolutionBar++;
        }
        else
        {
            gameManager.SpendCoins(-price);
            gameManager.StartEvolutionBarSpawn();
            gameManager.maxEvolutionBar--;
            upgrades.sliderEvolutionBarUI.SetActive(true);
            gameManager.levelEvolutionBar++;
        }
    }

    public void UpdateUI()
    {
        Texts.Instance.ChangeBuyEvolutionBarText(upgrades.priceEvolutionBar);
    }

    public void CheckLevel()
    {
        var gameManager = GameManager.Instance;
        var button = upgrades.buyEvolutionBar;

        if (gameManager.levelEvolutionBar >= 3 && gameManager.levelEvolutionBar < 5)
        {
            upgrades.priceEvolutionBar = gameManager.levelEvolutionBar;
            button.transform.Find("Image").GetComponent<Image>().sprite = upgrades.diamondsSprite;
            button.transform.parent.Find("Time").GetComponent<TextMeshProUGUI>().text = $"{gameManager.maxEvolutionBar}s-> {gameManager.maxEvolutionBar - 1}s";

            button.interactable = gameManager.diamonds >= upgrades.priceEvolutionBar;
        }
        else if (gameManager.levelEvolutionBar >= 5)
        {
            button.interactable = false;
        }
        else
        {
            button.transform.parent.Find("Time").GetComponent<TextMeshProUGUI>().text = $"{gameManager.maxEvolutionBar}s-> {gameManager.maxEvolutionBar - 1}s";
            button.interactable = gameManager.coins >= upgrades.priceEvolutionBar;
        }
    }
}
