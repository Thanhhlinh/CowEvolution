using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HatSelector : MonoBehaviour
{
    public Hat[] hats; // Danh sách các mũ
    public Button removeHatButton; // Button để gỡ mũ
    public static int currentCowLevel =0; // Cấp độ bò hiện tại

    private GameManager gameManager;
    private HatManager hatManager;
    private HatUIUpdate hatUIUpdate;

    void Start()
    {
        gameManager = GameManager.Instance;
        hatManager = HatManager.Instance;
        hatUIUpdate = GetComponent<HatUIUpdate>();
        hatUIUpdate.UpdateStartUI(hats);
    }

    private void Update()
    {
        hatUIUpdate.UpdateUsedHatTextUI(hats, gameManager.coins);
    }

    public void BuyHat(int index)
    {
        if (index >= 0 && index < hats.Length)
        {
            Hat selectedHat = hats[index];
            if (gameManager.coins >= selectedHat.cost)
            {
                selectedHat.currentHat++;
                gameManager.SpendCoins(-selectedHat.cost);
                hatUIUpdate.UpdateUsedHatText(hats);
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
                hatManager.GetHatForLevel(currentCowLevel).hatUsed--;
            }

            foreach (Cow cow in cows)
            {
                cow.EquipHat(selectedHat.hatPrefab);
            }
            hatUIUpdate.UpdateUsedHatText(hats);
            // Cập nhật thông tin mũ cho cấp độ
            hatManager.SetHatForLevel(currentCowLevel, selectedHat);
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
            hatManager.GetHatForLevel(currentCowLevel).hatUsed--;
            hatUIUpdate.UpdateUsedHatText(hats);
        }
        else if(hatManager.GetHatForLevel(currentCowLevel) != null)
        {
            hatManager.GetHatForLevel(currentCowLevel).hatUsed--;
            hatUIUpdate.UpdateUsedHatText(hats);
        }
        // Xóa thông tin mũ cho cấp độ hiện tại
        hatManager.RemoveHatForLevel(currentCowLevel);
    }

}
