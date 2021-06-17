using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    #region 
    public static GameManager Instance;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }
    #endregion

    public static bool isGameOver = false;
    public static bool isWin = false;
    public static bool isGoal = false;
    public static int difficulty = 0;

    MainMenu mainMenu;

    private void Start()
    {
        mainMenu = FindObjectOfType<MainMenu>();
    }

    private void Update()
    {
        if (isGameOver || isWin)
        {
            Time.timeScale = 0f;
        }
    }
}
