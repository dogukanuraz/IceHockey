using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackHole : MonoBehaviour
{
    LevelManager levelManager;

    private void Start()
    {
        levelManager = FindObjectOfType<LevelManager>();
    }

    private void Update()
    {
        if (levelManager.ballJumpCount<=20)
        {
            gameObject.transform.localScale = new Vector3(levelManager.ballJumpCount * 0.2f, levelManager.ballJumpCount * 0.4f);
        }        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {            
            levelManager.blueScore++;
            levelManager.turn = Turn.ENEMY;
            Goal(collision);            
        }
        if (collision.tag == "Enemy")
        {
            levelManager.redScore++;
            levelManager.turn = Turn.PLAYER;
            Goal(collision);
        }
    }

    void Goal(Collider2D collider)
    {
        GameManager.isGoal = true;
        Destroy(this.gameObject);
        Destroy(collider.gameObject);
    }
}
