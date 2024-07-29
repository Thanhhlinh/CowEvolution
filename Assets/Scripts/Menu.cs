using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour
{
    public GameObject menuUI,optionUI,achievementUI,moopediaUI;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OpenClose_Menu()
    {
        if (AudioManager.Instance.soundEffectToggle.isOn)
        {
            AudioManager.Instance.PlayCloseSound();
        }
        menuUI.SetActive(!menuUI.activeSelf);
        optionUI.SetActive(false);
        achievementUI.SetActive(false);
        moopediaUI.SetActive(false);
    }

    public void OpenClose_Option()
    {
        optionUI.SetActive(!optionUI.activeSelf);
    }
    public void OpenClose_Achievement()
    {
        achievementUI.SetActive(!achievementUI.activeSelf);
    }
    public void OpenClose_Moopedia()
    {
        moopediaUI.SetActive(!moopediaUI.activeSelf);
    }
}
