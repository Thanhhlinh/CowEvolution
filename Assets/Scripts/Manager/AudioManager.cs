using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    private void Awake()
    {
        Instance = this;
    }
    public AudioSource backgroundMusic, poopAudioSource, crateAudioSource , evolveAudioSource , closeAudioSource , spendAudioSource;
    public AudioClip poopAudioClip , crateAudioClip , evolveAudioClip , closeAudioClip , spendAudioClip , addCoinAudioClip;
    public Toggle musicToggle , soundEffectToggle;
    // Start is called before the first frame update
    void Start()
    {
        poopAudioSource.clip = poopAudioClip;
        crateAudioSource.clip = crateAudioClip;
        evolveAudioSource.clip = evolveAudioClip;
        closeAudioSource.clip = closeAudioClip;
        spendAudioSource.clip = spendAudioClip;
    }

    // Update is called once per frame
    void Update()
    {
        ToggleMusic();
    }
    
    public void ToggleMusic()
    {
        backgroundMusic.mute = !musicToggle.isOn;
    }

    public void PlayPoopSound()
    {
        poopAudioSource.Play();
    }

    public void PlayCrateSound()
    {
        crateAudioSource.Play();
    }

    public void PlayEvolveSound()
    {
        evolveAudioSource.Play();
    }

    public void PlayCloseSound()
    {
        closeAudioSource.Play();
    }

    public void PlaySpendCoinSound()
    {
        spendAudioSource.clip = spendAudioClip;
        spendAudioSource.Play();
    }

    public void PlayAddCoinSound()
    {
        spendAudioSource.clip = addCoinAudioClip;
        spendAudioSource.Play();
    }
}
