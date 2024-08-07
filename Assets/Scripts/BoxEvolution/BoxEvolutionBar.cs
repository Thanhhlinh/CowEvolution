using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BoxEvolutionBar : MonoBehaviour
{
    private void OnMouseDown()
    {
        OpenCrate();
    }


    public void OpenCrate()
    {
        GameManager.Instance.unboxEvolutionBar = true;
        GameManager.Instance.sumCrate--;
        Destroy(gameObject);
    }

}
