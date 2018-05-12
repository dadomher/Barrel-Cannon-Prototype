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
    public int preventsRepetition = 25;
    public Text scoreText, bonusText;

    private int score = 0, bonusLvl = 0;

    private int counterTimesIncrement = 0;
    private int timeAplied;
    private int contadorSpawnEnemies = 10;

    public float gameTime;


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
        
        if(gameOver == false && (int)gameTime == contadorSpawnEnemies) {
            for(int i = 0; i < Random.Range(1,3); i++) {
                ColumnPool.instance.createEnemy();
            }
            contadorSpawnEnemies += Random.Range(2, 5);
        }
        if (preventsRepetition <= gameTime && gameTime % timeAplied >= 0 && counterTimesIncrement < 5) {
            scrollSpeed += -0.25f;
            preventsRepetition += timeAplied;
            counterTimesIncrement++;
            print(scrollSpeed);
        }
    }

    public void PlayerScored() {
        if (gameOver) return;

        if (bonusLvl == 1) {
            score += 100;
            scoreText.text = "Score: " + score.ToString();
        } else if (bonusLvl == 2) {
            score += 150;
            scoreText.text = "Score: " + score.ToString();
        } else if (bonusLvl == 3) {
            score += 250;
            scoreText.text = "Score: " + score.ToString();
        } else if (bonusLvl == 4) {
            score += 500;
            scoreText.text = "Score: " + score.ToString();
        } 
    }

    public void FixBonus(float bonusTime) {
        if (bonusLvl == 0){
            bonusLvl++;
            bonusText.text = "Bonus: " + bonusLvl.ToString();
        }
        else if (bonusLvl == 1 && bonusTime < 5.0f) {
            bonusLvl++;
            bonusText.text = "Bonus: " + bonusLvl.ToString();
        }
        else if (bonusLvl == 2 && bonusTime < 4.25f) {
            bonusLvl++;
            bonusText.text = "Bonus: " + bonusLvl.ToString();
        }
        else if (bonusLvl == 3 && bonusTime < 3.50f) {
            bonusLvl++;
            bonusText.text = "Bonus: " + bonusLvl.ToString();
        }
        else {
            bonusLvl = 1;
            bonusText.text = "Bonus: " + bonusLvl.ToString();
        }

        print(bonusTime + " -> " + bonusLvl);
    }

    public void PlayerDied() {
        gameOverText.SetActive(true);
        gameOver = true;
    }

    public float sentGameTime() {
        return gameTime;
    }

}
