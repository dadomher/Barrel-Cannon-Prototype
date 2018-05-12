using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ambienMusicScript : MonoBehaviour {
    public static ambienMusicScript instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void ambienMusicEnable() {
        this.GetComponent<AudioSource>().enabled = !this.GetComponent<AudioSource>().enabled;
    }
}
