using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public Text scoreLabel;
    public playerController player;
    public int scoringFactor;
    public GameObject gameOverPanel;

    Vector3 initialPosition;
    private bool gameOver;

    // Start is called before the first frame update
    void Start()
    {
        gameOver = false;
        initialPosition = player.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (gameOver) return;

        Vector3 distance = player.transform.position - initialPosition;
        float score = distance.z / scoringFactor;
        scoreLabel.text = score.ToString("0");
    }

    public void GameOver()
    {
        gameOver = true;
        player.gameOver = true;
        gameOverPanel.SetActive(true);
    }

    public void ReloadLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
