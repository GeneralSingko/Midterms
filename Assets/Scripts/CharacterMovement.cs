using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterMovement : MonoBehaviour
{
    public float moveSpeed = 5f;

    void Update()
    {
        PlayerMove();
    }

    private void PlayerMove()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        // Calculate the new position based on user input
        float newX = transform.position.x + horizontalInput * moveSpeed * Time.deltaTime;
        float newY = transform.position.y + verticalInput * moveSpeed * Time.deltaTime;

        // Update the position
        transform.position = new Vector3(newX, newY, transform.position.z);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Collision detected!");
        // Check if the collision is with the barricade
        if (collision.gameObject.CompareTag("Barricade"))
        {
            // Prevent player from moving further into the barricade
            transform.position = new Vector2(transform.position.x - 0.1f * Mathf.Sign(transform.position.x - collision.transform.position.x), transform.position.y);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Exit"))
        {
            SceneManager.LoadScene("WinningScene");
        }
    }
}
