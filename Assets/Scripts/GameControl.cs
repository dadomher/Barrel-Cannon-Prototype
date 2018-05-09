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
    public Text scoreText;

    private int score = 0;
    private float gameTime = 0.0f;
    private int counterTimesIncrement = 0;
    private int preventsRepetition = 10;

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
		
	}

    // Update is called once per frame
    void Update() {
        gameTime += Time.deltaTime;
        if (gameOver == true && Input.GetKeyDown(KeyCode.Space)) {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        
        if (preventsRepetition <= gameTime && gameTime % 20 >= 0 && counterTimesIncrement < 6) {
            scrollSpeed += -0.25f;
            preventsRepetition += 10;
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
