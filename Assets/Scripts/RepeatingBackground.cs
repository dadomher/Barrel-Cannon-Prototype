﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatingBackground : MonoBehaviour {

    private BoxCollider2D groundCollider;
    private float groundHoritzontalLength;

	// Use this for initialization
	void Start () {
        groundCollider = GetComponent<BoxCollider2D>();
        groundHoritzontalLength = groundCollider.size.x;
	}
	
	// Update is called once per frame
	void Update () {
        if (transform.position.x < -groundHoritzontalLength) RepositionBackground();
	}

    private void RepositionBackground() {
        Vector2 groundOffset = new Vector2(groundHoritzontalLength * 2f, 0);
        transform.position = (Vector2)transform.position + groundOffset - new Vector2 (0.3f, 0f);
    }
}
