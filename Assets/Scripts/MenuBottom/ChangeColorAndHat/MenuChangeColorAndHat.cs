using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuChangeColorAndHat : MonoBehaviour
{
    public GameObject menuChangeColorAndHatUI, changeHatUI, changeColorUI;
    private ICommandMenuHatAndChangColor openCloseMenuCommand;
    private ICommandMenuHatAndChangColor openCloseHatCommand;
    private ICommandMenuHatAndChangColor openCloseColorCommand;
    // Start is called before the first frame update
    void Start()
    {
        AudioManager audioManager = AudioManager.Instance;
        openCloseMenuCommand = new OpenCloseMenuCommand(menuChangeColorAndHatUI, changeHatUI, changeColorUI, audioManager);
        openCloseHatCommand = new OpenCloseHatCommand(changeHatUI, audioManager);
        openCloseColorCommand = new OpenCloseColorCommand(changeColorUI, audioManager);
    }

    public void OpenClose_MenuChangeColorAndHat()
    {
        openCloseMenuCommand.Execute();
    }

    public void OpenClose_ChangeHat()
    {
        openCloseHatCommand.Execute();
    }
    public void OpenClose_ChangeColorUI()
    {
        openCloseColorCommand.Execute();
    }

}
