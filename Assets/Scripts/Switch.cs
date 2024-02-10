using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class Switch : MonoBehaviour
{

    private float detectionRange = 1f;
    public Transform playerTransform;

    public Color touchedColor = Color.yellow;
    private SpriteRenderer spriteRenderer;

    public UnityAction OnSwitchActivated;
    public bool IsActivated { get; private set; } = false;
    private GateRequirement gate;

    AudioManager audioManager;
    private bool soundPlayed = false;

    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }


    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        gate = FindObjectOfType<GateRequirement>();
    }

    void Update()
    {
        float distance = CalculatedDistance(playerTransform.position, transform.position);

        SwitchActivate(distance);
    }

    private float CalculatedDistance(Vector3 position1, Vector3 position2)
    {
        float deltaX = position1.x - position2.x;
        float deltaY = position1.y - position2.y;

        float distance = deltaX * deltaX + deltaY * deltaY;

        return distance;
    }

    private void IsSwitchTouched()
    {
        spriteRenderer.color = touchedColor;
        IsActivated = true;
        OnSwitchActivated?.Invoke();
    }

    private void SwitchActivate(float distance)
    {
        if (distance < detectionRange && gate != null)
        {
            IsSwitchTouched();
            Debug.Log("Player touched the switch");
            if (!soundPlayed)
            {
                audioManager.PlaySFX(audioManager.switchPing);
                soundPlayed = true;
            }
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, detectionRange);
    }
}