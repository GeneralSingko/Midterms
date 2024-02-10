using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerDetection : MonoBehaviour
{
    public float detectionRange = 1f;
    private Transform playerTransform;

    private void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void Update()
    {
        float distance = CalculatedDistance(playerTransform.position, transform.position);

        if (distance < detectionRange)
        {
            DeadScene();

        }
    }

    private float CalculatedDistance(Vector3 position1, Vector3 position2)
    {
        float deltaX = position1.x - position2.x;
        float deltaY = position1.y - position2.y;

        float distance = deltaX * deltaX + deltaY * deltaY;
        
        return distance;
    }

    private void DeadScene()
    {
        SceneManager.LoadScene("DeathScene");
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, detectionRange);
    }
}
