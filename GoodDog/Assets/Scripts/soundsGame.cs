using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class soundsGame : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip jumpSound, coinSound, winSound, loseSound, heartSound, doorSound, keySound, hitSound,trampolineSound, redButtonSound;

    public void playJumpSound()
    {
        audioSource.PlayOneShot(jumpSound);
    }

    public void playCoinSound()
    {
        audioSource.PlayOneShot(coinSound);
    }

    public void playWinSound()
    {
        audioSource.PlayOneShot(winSound);
    }

    public void playLoseSound()
    {
        audioSource.PlayOneShot(loseSound);
    }

    public void playHeartSound()
    {
        audioSource.PlayOneShot(heartSound);
    }

    public void playDoorSound()
    {
        audioSource.PlayOneShot(doorSound);
    }

    public void playKeySound()
    {
        audioSource.PlayOneShot(keySound);
    }

    public void playHitSound()
    {
        audioSource.PlayOneShot(hitSound);
    }

    public void playRedButtonSound()
    {
        audioSource.PlayOneShot(redButtonSound);
    }

    public void playTrampolineSound()
    {
        audioSource.PlayOneShot(trampolineSound);
    }
}
