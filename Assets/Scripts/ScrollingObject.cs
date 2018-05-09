using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingObject : MonoBehaviour {

    private Rigidbody2D rb2d;
    private float scrollSpeedAct;

	// Use this for initialization
	void Start () {
        rb2d = GetComponent<Rigidbody2D>();
        scrollSpeedAct = GameControl.instance.scrollSpeed;
        rb2d.velocity = new Vector2(scrollSpeedAct, 0);
    }
	
	// Update is called once per frame
	void Update () {
        if(scrollSpeedAct != GameControl.instance.scrollSpeed) {
            scrollSpeedAct = GameControl.instance.scrollSpeed;
            rb2d.velocity = new Vector2(scrollSpeedAct, 0);
        }
		if(GameControl.instance.gameOver) {
            rb2d.velocity = Vector2.zero;
        }
	}

    private void OnCollisionEnter2D(Collision2D collision) {
        
    }
}
