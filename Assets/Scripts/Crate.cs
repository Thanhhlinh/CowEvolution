using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crate : MonoBehaviour
{
   
    private void OnMouseDown()
    {
        OpenCrate();
    }

   
    public void OpenCrate()
    {
        if (AudioManager.Instance.soundEffectToggle.isOn)
        {
            AudioManager.Instance.PlayCrateSound();
        }
        GameManager.Instance.SpawnCowAt(transform.position);
        GameManager.Instance.sumCrate--;
        if (GameManager.Instance.boughtEvolutionBar)
        {
            GameManager.Instance.currentEvolutionBar++;
        } 
        Destroy(gameObject);
    }
}
