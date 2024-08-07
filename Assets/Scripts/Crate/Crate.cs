using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Crate : MonoBehaviour
{
    private GameManager gameManager;
    private AudioManager audioManager;
    private void Start()
    {
        gameManager = GameManager.Instance;
        audioManager = AudioManager.Instance;
        AnimationCrate();
    }
    
    private void OnMouseDown()
    {
        OpenCrate();
    }

    public void AnimationCrate()
    {
        Vector3 targetPos = new Vector3(transform.position.x, Random.Range(-4.5f, 4.7f), 0);
        float duration = 1f;
        transform.DOMove(targetPos, duration).SetEase(Ease.InOutSine);
    }
    public void OpenCrate()
    {
        if (audioManager.soundEffectToggle.isOn)
        {
            audioManager.PlayCrateSound();
        }
        SpawnManager.Instance.SpawnCowAt(transform.position);
        gameManager.sumCrate--;
        if (gameManager.boughtEvolutionBar)
        {
            gameManager.currentEvolutionBar++;
        } 
        Destroy(gameObject);
    }
}
