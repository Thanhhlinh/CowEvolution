using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Crate : MonoBehaviour
{
    private void Start()
    {
        AnimationCrate();
    }
    private void Update()
    {
        
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
