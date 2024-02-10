using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFollow : MonoBehaviour
{
    public float speed = 1.5f;
    private Transform target;

    private void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        Vector3 direction = target.position - transform.position;
        direction.Normalize();

        transform.Translate(direction * speed * Time.deltaTime);
    }

}
