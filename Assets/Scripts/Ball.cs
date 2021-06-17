using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    Rigidbody2D ballRb;
    LevelManager levelManager;
       
    private void Start()
    {
        levelManager = FindObjectOfType<LevelManager>();
        ballRb = GetComponent<Rigidbody2D>();
        levelManager.ballJumpCount = 1;

        if (levelManager.turn == Turn.PLAYER)
        {
            ballRb.velocity = new Vector2(0f, -levelManager.ballJumpForce);
        }
        else if (levelManager.turn == Turn.ENEMY)
        {
            ballRb.velocity = new Vector2(0f, levelManager.ballJumpForce);
        }
    }
   
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player" || collision.tag == "Enemy")
        {
            levelManager.ballJumpCount++;
        }
        if (gameObject.transform.position.y < 0)
        {
            ForceBall(collision, levelManager.ballJumpForce, levelManager.ballJumpForce);
        }
        if (gameObject.transform.position.y > 0)
        {
            ForceBall(collision, levelManager.ballJumpForce, -levelManager.ballJumpForce);
        }
    }

    void ForceBall(Collider2D collider,float forceX, float forceY)
    {
        if (collider.tag == "LEFT")
        {            
            ballRb.velocity = new Vector2(-forceX/2 , forceY/3);            
        }
        else if (collider.tag == "MID")
        {
            ballRb.velocity = new Vector2(0f, forceY);
        }
        else if (collider.tag == "RIGHT")
        {
            ballRb.velocity = new Vector2(forceX/2, forceY /3);
        }       
    }   
}
