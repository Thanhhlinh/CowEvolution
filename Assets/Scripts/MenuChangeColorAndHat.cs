using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuChangeColorAndHat : MonoBehaviour
{
    public GameObject menuChangeColorAndHatUI, changeHatUI, changeColorUI;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OpenClose_MenuChangeColorAndHat()
    {
        if (AudioManager.Instance.soundEffectToggle.isOn)
        {
            AudioManager.Instance.PlayCloseSound();
        }
        menuChangeColorAndHatUI.SetActive(!menuChangeColorAndHatUI.activeSelf);
        changeHatUI.SetActive(false);
        changeColorUI.SetActive(false);
    }

    public void OpenClose_ChangeHat()
    {
        changeHatUI.SetActive(!changeHatUI.activeSelf);
    }
    public void OpenClose_ChangeColorUI()
    {
        changeColorUI.SetActive(!changeColorUI.activeSelf);
    }
    
}
