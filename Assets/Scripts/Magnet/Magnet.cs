using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Magnet : MonoBehaviour
{
    public Image magnetUI;
    public Sprite onMagnet , offMagnet;
    private GameManager gameManager;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameManager.Instance;
    }

    public void ChangeMagnetOnOff()
    {
        gameManager.isAutoEvolveEnabled = !gameManager.isAutoEvolveEnabled;
        if (gameManager.isAutoEvolveEnabled)
        {
            magnetUI.sprite = onMagnet;
        }
        else
        {
            magnetUI.sprite = offMagnet;
        }
    }
}
