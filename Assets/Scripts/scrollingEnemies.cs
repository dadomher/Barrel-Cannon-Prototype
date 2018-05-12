using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scrollingEnemies : MonoBehaviour
{

    private Rigidbody2D rb2d;
    public float scrollSpeed;

    // Use this for initialization
    void Start() {
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update() {
        scrollSpeed = Random.Range(-4.0f, -8.0f);
        rb2d.velocity = new Vector2(scrollSpeed, (-1)* scrollSpeed);

        
        if (GameControl.instance.gameOver) {
            rb2d.velocity = Vector2.zero;
        }
    }
}
