using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameControl : MonoBehaviour {

    public static GameControl instance;
    public float scrollSpeed = -2f;
    public bool gameOver = false;

    private void Awake() {
        if (instance == null) instance = this;
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
