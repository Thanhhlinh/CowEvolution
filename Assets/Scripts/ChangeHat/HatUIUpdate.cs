using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HatUIUpdate : MonoBehaviour
{
    public TextMeshProUGUI[] costTexts;
    public TextMeshProUGUI[] usedHatText;
    public Button[] usedHatBTN;
    public Button[] buyHatBTN;

    public void UpdateStartUI(Hat[] hats)
    {
        for (int i = 0; i < hats.Length; i++)
        {
            costTexts[i].text = hats[i].cost.ToString();
            usedHatText[i].text = $"{hats[i].hatUsed}/{hats[i].currentHat}";
        }
    }

    public void UpdateUsedHatTextUI(Hat[] hats, int coins)
    {
        for (int i = 0; i < hats.Length; i++)
        {
            buyHatBTN[i].interactable = coins >= hats[i].cost;
            usedHatBTN[i].interactable = hats[i].hatUsed < hats[i].currentHat;
        }
    }

    public void UpdateUsedHatText(Hat[] hats)
    {
        for (int i = 0; i < hats.Length; i++)
        {
            usedHatText[i].text = $"{hats[i].hatUsed}/{hats[i].currentHat}";
        }
    }
}
