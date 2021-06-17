using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public Dropdown dropdown;

    int dropdownValue;

    private void Update()
    {
        dropdownValue = dropdown.value;
    }

    public void GameStart()
    {
        Time.timeScale = 1;
        GameManager.isWin = false;
        GameManager.isGameOver = false;
        GameManager.difficulty = dropdownValue;
        SceneManager.LoadScene(1);
    }
}
