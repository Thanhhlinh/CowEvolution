using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ICommandMenuHatAndChangColor
{
    void Execute();
}

public class OpenCloseMenuCommand : ICommandMenuHatAndChangColor
{
    private GameObject menu;
    private GameObject changeHatUI;
    private GameObject changeColorUI;
    private AudioManager audioManager;

    public OpenCloseMenuCommand(GameObject menu, GameObject changeHatUI, GameObject changeColorUI, AudioManager audioManager)
    {
        this.menu = menu;
        this.changeHatUI = changeHatUI;
        this.changeColorUI = changeColorUI;
        this.audioManager = audioManager;
    }

    public void Execute()
    {
        if (audioManager.soundEffectToggle.isOn)
        {
            audioManager.PlayCloseSound();
        }
        menu.SetActive(!menu.activeSelf);
        changeHatUI.SetActive(false);
        changeColorUI.SetActive(false);
    }
}

public class OpenCloseHatCommand : ICommandMenuHatAndChangColor
{
    private GameObject changeHatUI;
    private AudioManager audioManager;

    public OpenCloseHatCommand(GameObject changeHatUI, AudioManager audioManager)
    {
        this.changeHatUI = changeHatUI;
        this.audioManager = audioManager;
    }

    public void Execute()
    {
        if (audioManager.soundEffectToggle.isOn)
        {
            audioManager.PlayCloseSound();
        }
        changeHatUI.SetActive(!changeHatUI.activeSelf);
    }
}

public class OpenCloseColorCommand : ICommandMenuHatAndChangColor
{
    private GameObject changeColorUI;
    private AudioManager audioManager;

    public OpenCloseColorCommand(GameObject changeColorUI, AudioManager audioManager)
    {

        this.changeColorUI = changeColorUI;
        this.audioManager = audioManager;
    }

    public void Execute()
    {
        if (audioManager.soundEffectToggle.isOn)
        {
            audioManager.PlayCloseSound();
        }
        changeColorUI.SetActive(!changeColorUI.activeSelf);
    }
}
