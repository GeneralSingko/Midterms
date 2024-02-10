using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Exit : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        /*if (other.CompareTag("Player"))
        {
            SceneManager.LoadScene("WinningScene");
            Debug.Log("Player is here");
        }*/

        Debug.Log("Somethings here");
    }
}
