using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LandmineDetect : MonoBehaviour
{
    public AudioClip soundClip;
    private AudioSource audioSource;

    public Transform player;
    public Transform[] landmines;

    public float pitchIncreaseDistance = 5f;
    public float pitchIncreaseSpeed = 1f;
    private float targetPitch = 1f;

    void Start()
    {
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.loop = true;
        audioSource.clip = soundClip;
        audioSource.Play();
    }

    private void Update()
    {
        float closestDistance = float.MaxValue; // closet distance of the landmines
        foreach (Transform landmine in landmines)
        {
            float distance = Vector3.Distance(player.position, landmine.position);
            closestDistance = Mathf.Min(closestDistance, distance);
        }

        if (closestDistance < pitchIncreaseDistance)
        {
            targetPitch = Mathf.Lerp(1f, 2f, closestDistance / pitchIncreaseDistance);
        }
        else
        {
            targetPitch = 1f;
        }

        audioSource.pitch = Mathf.Lerp(audioSource.pitch, targetPitch, pitchIncreaseSpeed * Time.deltaTime);
    }
}
