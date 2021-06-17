using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed;

    Vector3 touchPos;
    AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        touchPos = transform.position;
    }

    private void Update()
    {        
        if (Input.GetMouseButtonDown(0))
        {
            touchPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }

        if (touchPos.x <= -4)
        {
            touchPos.x = -4;
        }
        if (touchPos.x >= 4)
        {
            touchPos.x = 4;
        }

        transform.position = Vector2.MoveTowards(transform.position, new Vector2(touchPos.x, transform.position.y), moveSpeed * Time.deltaTime);        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        collision.tag = gameObject.tag;
        collision.GetComponent<SpriteRenderer>().color = gameObject.GetComponent<SpriteRenderer>().color;
        audioSource.Play();
    }
}
