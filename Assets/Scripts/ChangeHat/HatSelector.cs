using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HatSelector : MonoBehaviour
{
    public Hat[] hats; // Danh sách các mũ
    public TextMeshProUGUI[] costTexts; // Giá tiền của mũ
    public TextMeshProUGUI[] usedHatText; // số lượng mũ sử dụng
    public Button[] usedHatBTN;
    public Button[] buyHatBTN;
    public Button removeHatButton; // Button để gỡ mũ
    public static int currentCowLevel =0; // Cấp độ bò hiện tại

    void Start()
    {
        UpdateStartUI();
    }

    private void Update()
    {
        UpdateUsedHatTextUI();
    }

    public void BuyHat(int index)
    {
        if (index >= 0 && index < hats.Length)
        {
            Hat selectedHat = hats[index];
            if (GameManager.Instance.coins >= selectedHat.cost)
            {
                selectedHat.currentHat++;
                GameManager.Instance.SpendCoins(-selectedHat.cost);
                for (int i = 0; i < hats.Length; i++)
                {
                    usedHatText[i].text = hats[i].hatUsed.ToString() + "/" + hats[i].currentHat.ToString();
                }
            }
        }
    }
    public void UseHat(int hatIndex)
    {
        if (hatIndex >= 0 && hatIndex < hats.Length)
        {
            Hat selectedHat = hats[hatIndex];
            selectedHat.hatUsed++;
            
            // Tìm tất cả các con bò có cấp độ tương ứng
            Cow[] cows = FindObjectsOfType<Cow>().Where(cow => cow.tier == currentCowLevel).ToArray();

            bool hasHat = false;
            foreach (Cow cow in cows)
            {
                hasHat = cow.HasHat();
                cow.RemoveCurrentHat();
            }
            if (hasHat)
            {
                HatManager.Instance.GetHatForLevel(currentCowLevel).hatUsed--;
            }

            foreach (Cow cow in cows)
            {
                cow.EquipHat(selectedHat.hatPrefab);
            }
            for (int i = 0; i < hats.Length; i++)
            {
                usedHatText[i].text = hats[i].hatUsed.ToString() + "/" + hats[i].currentHat.ToString();
            }
            // Cập nhật thông tin mũ cho cấp độ
            HatManager.Instance.SetHatForLevel(currentCowLevel, selectedHat);
        }
    }

    public void RemoveHatFromCows()
    {
        
        // Tìm tất cả các con bò có cấp độ tương ứng
        Cow[] cows = FindObjectsOfType<Cow>().Where(cow => cow.tier == currentCowLevel).ToArray();
        bool hasHat =false;
        foreach (Cow cow in cows)
        {
            hasHat = cow.HasHat();
            cow.RemoveCurrentHat();
        }
        if(hasHat) {
            HatManager.Instance.GetHatForLevel(currentCowLevel).hatUsed--;
            for (int i = 0; i < hats.Length; i++)
            {
                usedHatText[i].text = hats[i].hatUsed.ToString() + "/" + hats[i].currentHat.ToString();
            }
        }else if(HatManager.Instance.GetHatForLevel(currentCowLevel) != null)
        {
            HatManager.Instance.GetHatForLevel(currentCowLevel).hatUsed--;
            for (int i = 0; i < hats.Length; i++)
            {
                usedHatText[i].text = hats[i].hatUsed.ToString() + "/" + hats[i].currentHat.ToString();
            }
        }
        // Xóa thông tin mũ cho cấp độ hiện tại
        HatManager.Instance.RemoveHatForLevel(currentCowLevel);
    }

    void UpdateStartUI()
    {
        for (int i = 0; i < hats.Length; i++)
        {
            costTexts[i].text = hats[i].cost.ToString();
        }
        for (int i = 0; i < hats.Length; i++)
        {
            usedHatText[i].text = hats[i].hatUsed.ToString() + "/" + hats[i].currentHat.ToString();
        }
    }

    void UpdateUsedHatTextUI()
    {
        if(GameManager.Instance.coins>= hats[0].cost)
        {
            buyHatBTN[0].interactable = true;
        }
        else
        {
            buyHatBTN[0].interactable = false;
        }

        if (GameManager.Instance.coins >= hats[1].cost)
        {
            buyHatBTN[1].interactable = true;
        }
        else
        {
            buyHatBTN[1].interactable = false;
        }

        if (GameManager.Instance.coins >= hats[2].cost)
        {
            buyHatBTN[2].interactable = true;
        }
        else
        {
            buyHatBTN[2].interactable = false;
        }

        if (hats[0].hatUsed < hats[0].currentHat)
        {
            usedHatBTN[0].interactable = true;
        }
        else
        {
            usedHatBTN[0].interactable = false;
        }

        if (hats[1].hatUsed < hats[1].currentHat)
        {
            usedHatBTN[1].interactable = true;
        }
        else
        {
            usedHatBTN[1].interactable = false;
        }

        if (hats[2].hatUsed < hats[2].currentHat)
        {
            usedHatBTN[2].interactable = true;
        }
        else
        {
            usedHatBTN[2].interactable = false;
        }
    }
}
