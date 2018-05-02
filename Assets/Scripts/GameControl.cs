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
	void Update () {
		if(gameOver == true && Input.GetKeyDown(KeyCode.Space)) {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
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
