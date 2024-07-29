using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ScrollToNextItem : MonoBehaviour
{
    public ScrollRect scrollRect; // Kéo Scroll View vào đây trong inspector
    public RectTransform content; // Kéo Content của Scroll View vào đây trong inspector
    private int numberOfItems; // Số lượng các GameObject trong Content
    private int currentItemIndex = 0; // Chỉ số của GameObject hiện tại

    private void Update()
    {
        ChangeColorCow.Instance.colorCowIndex = currentItemIndex;
        if (currentItemIndex == 0)
        {
            content.gameObject.transform.parent.transform.Find("LeftBTN").gameObject.SetActive(false);
        }else if (currentItemIndex == numberOfItems )
        {
            content.gameObject.transform.parent.transform.Find("RightBTN").gameObject.SetActive(false);
        }
        else
        {
            content.gameObject.transform.parent.transform.Find("LeftBTN").gameObject.SetActive(true);
            content.gameObject.transform.parent.transform.Find("RightBTN").gameObject.SetActive(true);
        }
        if (numberOfItems < GameManager.Instance.highest_Tier)
        {
            numberOfItems = GameManager.Instance.highest_Tier;
            for(int i = 0; i <= numberOfItems; i++)
            {
                Transform item = content.GetChild(i);
                item.gameObject.SetActive(true);
            }
        }
       
        
    }
    public void NextItem()
    {
        if (currentItemIndex < numberOfItems)
        {
            currentItemIndex++;
            UpdateScrollPosition();
        }
    }

    public void PreviousItem()
    {
        if (currentItemIndex > 0)
        {
            currentItemIndex--;
            UpdateScrollPosition();
        } 
    }

    private void UpdateScrollPosition()
    {
        float itemWidth = 1f / numberOfItems;
        float targetPosition = itemWidth * currentItemIndex;
        scrollRect.horizontalNormalizedPosition = targetPosition;
    }
}
