using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Magnet : MonoBehaviour
{
    public Image magnetUI;
    public Sprite onMagnet , offMagnet;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeMagnetOnOff()
    {
        GameManager.Instance.isAutoEvolveEnabled = !GameManager.Instance.isAutoEvolveEnabled;
        if (GameManager.Instance.isAutoEvolveEnabled)
        {
            magnetUI.sprite = onMagnet;
        }
        else
        {
            magnetUI.sprite = offMagnet;
        }
    }
}
