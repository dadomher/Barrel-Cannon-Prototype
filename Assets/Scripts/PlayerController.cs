using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    Rigidbody2D rb;

	// Use this for initialization
	void Start () {
        //aplicamos una fuerza de salida
        rb = GetComponent<Rigidbody2D>();
        rb.AddForce(transform.up * 600);
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
    }
}

