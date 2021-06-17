using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Turn
{
    PLAYER,
    ENEMY
}

public class LevelManager : MonoBehaviour
{
    public Turn turn;
    public int blueScore;
    public int redScore;
    public int ballJumpCount;
    public float ballJumpForce;    
    public GameObject ball;
    public GameObject blackHole;

    private void Start()
    {
        turn = Turn.PLAYER;
        blueScore = 0;
        redScore = 0;
        CreateLevel();
    }

    private void Update()
    {
        if (blueScore ==5)
        {
            GameManager.isWin = true;
        }
        else if (redScore == 5)
        {
            GameManager.isGameOver = true;
        }

        if (GameManager.isGoal)
        {
            StartCoroutine(CreateGameCo());
            GameManager.isGoal = false;
        }
    }

    IEnumerator CreateGameCo()
    {
        yield return new WaitForSeconds(1f);
        CreateLevel();        
    }

    public void CreateLevel()
    {
        float random = Random.Range(-4.5f, 4.5f);
        Instantiate(blackHole, new Vector2(random, 0), Quaternion.identity);

        if (turn == Turn.ENEMY)
        {
            Instantiate(ball, new Vector2(0, 3), Quaternion.identity);
        }
        else if (turn == Turn.PLAYER)
        {
            Instantiate(ball, new Vector2(0, -3), Quaternion.identity);
        }
    }
}
