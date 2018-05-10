using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameControl : MonoBehaviour {

    public static GameControl instance;
    public float scrollSpeed = -2f;
    public bool gameOver = false;
    public GameObject gameOverText;
    public int preventsRepetition = 30;
    public Text scoreText;

    private int score = 0;
    private float gameTime = 0.0f;
    private int counterTimesIncrement = 0;
    private int timeAplied;


    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this) {
            Destroy(gameObject);
        }
    }

    // Use this for initialization
    void Start () {
        timeAplied = preventsRepetition;
    }

    // Update is called once per frame
    void Update() {
        gameTime += Time.deltaTime;
        if (gameOver == true && Input.GetKeyDown(KeyCode.Space)) {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        
        if (preventsRepetition <= gameTime && gameTime % timeAplied >= 0 && counterTimesIncrement < 5) {
            scrollSpeed += -0.20f;
            preventsRepetition += timeAplied;
            counterTimesIncrement++;
            print(scrollSpeed);
        }
    }

    public void PlayerScored() {
        if (gameOver) return;
        score += 10;
        scoreText.text = "Score: " + score.ToString();
    }

    public void PlayerDied() {
        gameOverText.SetActive(true);
        gameOver = true;
    }
}
