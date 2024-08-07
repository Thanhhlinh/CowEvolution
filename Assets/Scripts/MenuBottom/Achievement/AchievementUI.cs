using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AchievementUI : MonoBehaviour
{
    public Button[] getRewardBTN;
    public GameObject[] imageSuccess;

    public void UpdateButtonInteractable(int index, bool interactable)
    {
        if (index >= 0 && index < getRewardBTN.Length)
        {
            getRewardBTN[index].interactable = interactable;
        }
    }

    public void ShowSuccessImage(int index)
    {
        if (index >= 0 && index < imageSuccess.Length)
        {
            getRewardBTN[index].gameObject.SetActive(false);
            imageSuccess[index].SetActive(true);
        }
    }
}