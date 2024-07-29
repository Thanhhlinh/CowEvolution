using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MenuMapDropDown : MonoBehaviour
{
    public GameObject camera;
    public TMP_Dropdown menuDropDown;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetMap(int index)
    {
        if(index == 0)
        {
            camera.transform.position = new Vector3(0, 0, -10);
        }
        else if(index == 1)
        {
            camera.transform.position = new Vector3(0, 0, -20);
        }
        else if (index == 2)
        {
            camera.transform.position = new Vector3(0, 0, -30);
        }
    }
}
