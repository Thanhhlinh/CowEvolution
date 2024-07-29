using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Texts : MonoBehaviour
{
    public static Texts Instance;
    public TextMeshProUGUI coinsText, diamondsText, buyUpgradeCrateText,buyUpgradeBerryDeliveryText , buyUpgradeMagnetText , buyEvolutionBarText;
    public TextMeshProUGUI[] buyCowText;
    private void Awake()
    {
        Instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeTextCoins(int amount)
    {
        coinsText.text = amount.ToString();
    }

    public void ChangeTextDiamonds(int amount)
    {
        diamondsText.text = amount.ToString();
    }

    public void ChangeBuyUpgradeCrateText(int amount)
    {
        buyUpgradeCrateText.text = amount.ToString();
    }

    public void ChangeBuyUpgradeBerryDeliveryText(int amount)
    {
        buyUpgradeBerryDeliveryText.text = amount.ToString();
    }

    public void ChangeBuyUpgradeMagnetText(int amount)
    {
        buyUpgradeMagnetText.text = amount.ToString();
    }

    public void ChangeBuyEvolutionBarText(int amount)
    {
        buyEvolutionBarText.text = amount.ToString();
    }


    public void ChangeBuyCowCoinsText(int index,int amount)
    {
        amount = Mathf.Abs(amount);
        buyCowText[index].text = amount.ToString();
    }
    
}
