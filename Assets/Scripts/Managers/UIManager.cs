using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject gameFailPanel;
    [SerializeField] private GameObject gamePanel;

    private TextMeshProUGUI levelText;
    private TextMeshProUGUI scoreText;
    
    
    private void Start()
    {
        EventsManager.Instance.onGameFailed += ActivateGameFailPanel;

        levelText = gamePanel.transform.Find("LevelText").GetComponent<TextMeshProUGUI>();
        scoreText = gamePanel.transform.Find("ScoreText").GetComponent<TextMeshProUGUI>();
        
    }

    private void Update()
    {
        UpdateLevelText();
        UpdateScoreText();
    }

    private void ActivateGameFailPanel()
    {
        gameFailPanel.SetActive(true);
        gamePanel.SetActive(false);
    }
    public void OnQuitButtonPressed()
    {
        Application.Quit();
    }

    private void UpdateLevelText()
    {
        levelText.text = "Level: " + GameManager.Instance.level;
    }

    private void UpdateScoreText()
    {
        scoreText.text = "Score: " + GameManager.Instance.score;
    }
}
