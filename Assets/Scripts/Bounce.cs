using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bounce : MonoBehaviour
{
    Rigidbody2D ballRB;
    Vector3 lastVelocity;

    private void Awake()
    {
        ballRB = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        lastVelocity = ballRB.velocity;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        var speed = lastVelocity.magnitude;
        var direction = Vector3.Reflect(lastVelocity.normalized, collision.contacts[0].normal);

        ballRB.velocity = direction * Mathf.Max(speed, 0f);
    }
}
