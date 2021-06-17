using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public PlayerMovement playerMovement;

    GameObject ball;
    GameObject blackHole;
    AudioSource audioSource;

    float moveSpeed;
    float posY;
    float holeXPos;
    float ballPosX;
    int difficultyLevel;


    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        difficultyLevel = GameManager.difficulty;
        posY = transform.position.y;
        moveSpeed = playerMovement.moveSpeed;
        ball = GameObject.FindGameObjectWithTag("Ball");
    }

    void Update()
    {        
        if (blackHole == null)
        {
            holeXPos = 0f;
            blackHole = GameObject.FindGameObjectWithTag("BlackHole");            
        }
        else
        {
            holeXPos = blackHole.transform.position.x;
        }
        
        if (ball == null)
        {
            ballPosX = 0;
            ball = GameObject.FindGameObjectWithTag("Ball");
        }
        else
        {
            ballPosX = ball.transform.position.x;
            switch (difficultyLevel)
            {
                case 0:
                    MoveStick(ballPosX,1f);
                    break;
                case 1:
                    MoveStick(ballPosX,.5f);
                    break;
                case 2:
                    MoveStick(ballPosX, 0f);
                    break;
                case 3:
                    MoveStick((ballPosX + holeXPos)/2, 0f);
                    break;
                case 4:
                    MoveStick((ballPosX + holeXPos) / 2, 1f);
                    break;
                default:
                    break;
            }
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        collision.tag = gameObject.tag;
        collision.GetComponent<SpriteRenderer>().color = gameObject.GetComponent<SpriteRenderer>().color;
        audioSource.Play();
    }

    void MoveStick(float ballPos,float value)
    {        
        if (ballPosX >= -4 && ballPosX <= 4)
        {
            
            if (ballPosX <= 0)
            {
                transform.position = Vector2.MoveTowards(transform.position, new Vector2(ballPos - value, posY), moveSpeed * Time.deltaTime);
            }
            if (ballPosX > 0)
            {
                transform.position = Vector2.MoveTowards(transform.position, new Vector2(ballPos + value, posY), moveSpeed * Time.deltaTime);
            }
        }
    }
}
