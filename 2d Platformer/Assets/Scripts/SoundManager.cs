using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static AudioClip JumpSound, StompSound, DeathSound, WinSound, CoinSound;
    static AudioSource audioSource;
    void Start()
    {
        JumpSound = Resources.Load<AudioClip> ("Jump");
        StompSound = Resources.Load<AudioClip> ("Stomp");
        DeathSound = Resources.Load<AudioClip> ("Death");
        WinSound = Resources.Load<AudioClip> ("Win");
        CoinSound = Resources.Load<AudioClip> ("Coin");

        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static void PlaySound (string clip)
    {
        switch (clip)
        {
            case "Jump":
                audioSource.PlayOneShot (JumpSound);
                break;
            case "Stomp":
                audioSource.PlayOneShot (StompSound);
                break;
            case "Death":
                audioSource.PlayOneShot (DeathSound);
                break;
            case "Win":
                audioSource.PlayOneShot (WinSound);
                break;
            case "Coin":
                audioSource.PlayOneShot (CoinSound);
                break;
        }
    }
}
