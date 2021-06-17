using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public Text blueScoreText;
    public Text redScoreText;
    public GameObject winPanel;
    public GameObject losePanel;
    public LevelManager levelManager;

    private void Update()
    {
        blueScoreText.text = levelManager.blueScore.ToString();
        redScoreText.text = levelManager.redScore.ToString();

        if (GameManager.isGameOver)
        {
            losePanel.SetActive(true);
        }

        if (GameManager.isWin)
        {
            winPanel.SetActive(true);
        }    
    }

    public void GoBackManu()
    {        
        SceneManager.LoadScene(0);        
    }
}
