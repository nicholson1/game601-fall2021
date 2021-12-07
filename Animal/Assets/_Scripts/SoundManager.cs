using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class SoundManager : MonoBehaviour
{
    private bool is_muted = false;

    public AudioClip[] footsteps;
    public AudioSource PlayerSounds;

    public AudioClip MenuButton;
    public AudioClip Landing;
    public AudioClip questComplete;

    private void Start()
    {
        // AudioListener[] listeners = FindObjectsOfType<AudioListener>();
        // foreach (var VARIABLE in listeners)
        // {
        //     Debug.Log(VARIABLE.gameObject.name);
        // }
    }

    public void ToggleMute()
    {
        is_muted = !is_muted;
        GetComponent<AudioListener>().enabled = is_muted;
    }

    private int lastIndex;
    public void playRandomFootstep()
    {
        int newIndex = lastIndex;
        while (newIndex == lastIndex)
        {
            newIndex = Random.Range(0, footsteps.Length);
        }
        PlayerSounds.PlayOneShot(footsteps[newIndex], .1f);
        lastIndex = newIndex;
    }

    public void landingSound()
    {
        PlayerSounds.PlayOneShot(Landing, .1f);
    }

    public void MenuButtonSound()
    {
        PlayerSounds.PlayOneShot(MenuButton, .1f);
    }

    public void PlayQuestCompleteSound()
    {
        PlayerSounds.PlayOneShot(questComplete, .1f);

    }
}
