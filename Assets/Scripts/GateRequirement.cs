using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateRequirement : MonoBehaviour
{
    public Switch[] switches;

    AudioManager audioManager;
    private bool soundPlayed = false;

    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    private void Start()
    {
        foreach (Switch s in switches)
        {
            s.OnSwitchActivated += CheckSwitches;
        }
    }

    void CheckSwitches()
    {
        // Check if all switches are activated
        bool allActivated = true;
        foreach (Switch s in switches)
        {
            if (!s.IsActivated)
            {
                allActivated = false;
                break;
            }
        }

        if (allActivated)
        {
            Destroy(gameObject);
            if (!soundPlayed)
            {
                audioManager.PlaySFX(audioManager.gateOpened);
                soundPlayed = true;
            }
        }

    }

}