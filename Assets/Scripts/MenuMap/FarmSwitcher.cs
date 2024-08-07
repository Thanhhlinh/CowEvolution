using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using UnityEngine.UI;


public class FarmSwitcher : MonoBehaviour
{
    public GameObject farmSelectedUI;
    public Button arrowDownButton; // Nút mũi tên
    public Button arrowUpButton;
    public GameObject farmMenu; // Menu chứa các farm
    public Button[] farmButtons; // Các Button đại diện cho farm
    public Image selectionArrow; // Mũi tên chỉ vào farm đang được chọn
    public Transform mainCamera; // Camera chính
    public Transform[] farms; // Các trang trại

    private int selectedFarmIndex = 0;
    public bool isMenuOpen = false;
    private float transitionDuration = 0.5f; // Thời gian chuyển đổi
    public Image selectedFarmImage;

    public void OpenMenu()
    {
        isMenuOpen = true;
        farmMenu.SetActive(true);
        farmSelectedUI.SetActive(false);
        StartCoroutine(TransitionToFarm(selectedFarmIndex));
    }

    public void CloseMenu()
    {
        isMenuOpen = false;
        farmMenu.SetActive(false);
        farmSelectedUI.SetActive(true);

        UpdateSelectedFarmImage();
    }

    public void SelectFarm(int index)
    {
        if (selectedFarmIndex != index)
        {
            StartCoroutine(TransitionToFarm(index));
        }
    }
    private IEnumerator TransitionToFarm(int newFarmIndex)
    {
        ShowSelectionArrow(newFarmIndex);
        if (selectedFarmIndex == newFarmIndex)
        {

        }
        else if (selectedFarmIndex < newFarmIndex)
        {
            yield return ScaleFarmDown(newFarmIndex);
        }
        else
        {
            yield return ScaleFarmUp(newFarmIndex);
        }

        MoveCameraToFarm(newFarmIndex);

        selectedFarmIndex = newFarmIndex;
    }

    private void ShowSelectionArrow(int newFarmIndex)
    {
        selectionArrow.gameObject.SetActive(true);
        Vector3 startArrowPosition = selectionArrow.transform.position;
        Vector3 endArrowPosition = new Vector3(selectionArrow.transform.position.x, farmButtons[newFarmIndex].transform.position.y, 0);

        StartCoroutine(MoveSelectionArrow(startArrowPosition, endArrowPosition));
    }

    private IEnumerator MoveSelectionArrow(Vector3 start, Vector3 end)
    {
        float elapsedTime = 0;
        while (elapsedTime < transitionDuration)
        {
            elapsedTime += Time.deltaTime;
            float t = elapsedTime / transitionDuration;
            selectionArrow.transform.position = Vector3.Lerp(start, end, t);
            yield return null;
        }
    }

    private IEnumerator ScaleFarmDown(int farmIndex)
    {
        float elapsedTime = 0;
        Transform currentFarm = farms[selectedFarmIndex];

        Vector3 originalScale = currentFarm.localScale;
        Vector3 targetScale = Vector3.zero;

        while (elapsedTime < transitionDuration)
        {
            elapsedTime += Time.deltaTime;
            float t = elapsedTime / transitionDuration;
            currentFarm.localScale = Vector3.Lerp(originalScale, targetScale, t);
            yield return null;
        }
        farms[farmIndex].localScale = Vector3.one;
    }

    private IEnumerator ScaleFarmUp(int farmIndex)
    {

        Transform currentFarm = farms[selectedFarmIndex];
        Vector3 originalScale = currentFarm.localScale;
        Vector3 targetScale = new Vector3(2, 2, 2);
        float elapsedTime = 0;
        while (elapsedTime < transitionDuration)
        {
            elapsedTime += Time.deltaTime;
            float t = elapsedTime / transitionDuration;
            currentFarm.localScale = Vector3.Lerp(originalScale, targetScale, t);
            yield return null;
        }
        farms[farmIndex].localScale = Vector3.one;
    }

    private void MoveCameraToFarm(int farmIndex)
    {
        float zOffset = -10 * (farmIndex + 1);
        mainCamera.position = new Vector3(0, 0, zOffset);
    }

    void UpdateSelectedFarmImage()
    {
        selectedFarmImage.sprite = farmButtons[selectedFarmIndex].GetComponent<Image>().sprite;
    }
}










/*IEnumerator TransitionToFarm(int newFarmIndex)
    {
        // Hiển thị mũi tên chỉ vào farm đang được chọn
        selectionArrow.gameObject.SetActive(true);
        Vector3 startArrowPosition = selectionArrow.transform.position;
        Vector3 endArrowPosition = new Vector3(selectionArrow.transform.position.x, farmButtons[newFarmIndex].transform.position.y,0) ;

        // Di chuyển mũi tên từ từ đến farm được chọn
        float elapsedTime = 0;
        while (elapsedTime < transitionDuration)
        {
            elapsedTime += Time.deltaTime;
            float t = elapsedTime / transitionDuration;
            selectionArrow.transform.position = Vector3.Lerp(startArrowPosition, endArrowPosition, t);
            yield return null;
        }
        // Hiệu ứng thu nhỏ farm hiện tại hoặc zoom gần vào farm hiện tại
        if(selectedFarmIndex < newFarmIndex) 
        {
            elapsedTime = 0;
            Transform currentFarm = farms[selectedFarmIndex];

            Vector3 originalScale = currentFarm.localScale;
            Vector3 targetScale =  Vector3.zero;

            while (elapsedTime < transitionDuration)
            {
                elapsedTime += Time.deltaTime;
                float t = elapsedTime / transitionDuration;
                currentFarm.localScale = Vector3.Lerp(originalScale, targetScale, t);
                yield return null;
            }
            farms[newFarmIndex].localScale = Vector3.one;
        }
        else if(selectedFarmIndex > newFarmIndex)
        {
            elapsedTime = 0;
            Transform currentFarm = farms[selectedFarmIndex];

            Vector3 originalScale = currentFarm.localScale;
            Vector3 targetScale = new Vector3(2,2,2);

            while (elapsedTime < transitionDuration)
            {
                elapsedTime += Time.deltaTime;
                float t = elapsedTime / transitionDuration;
                currentFarm.localScale = Vector3.Lerp(originalScale, targetScale, t);
                yield return null;
            }
            farms[newFarmIndex].localScale = Vector3.one;
        }
        



        // Di chuyển camera đến farm mới
        if (newFarmIndex == 0)
        {
            mainCamera.position = new Vector3(0, 0, -10);
        }
        else if (newFarmIndex == 1)
        {
            mainCamera.position = new Vector3(0, 0, -20);
        }
        else if (newFarmIndex == 2)
        {
            mainCamera.position = new Vector3(0, 0, -30);
        }

        selectedFarmIndex = newFarmIndex;
    }*/
