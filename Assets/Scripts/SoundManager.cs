using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour {

    public AudioClip buttonSound, cannonSound, dieSound;
    AudioSource fuenteAudio;
    public static SoundManager instance;

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
        fuenteAudio = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void buttonPlaySound(){
        fuenteAudio.clip = buttonSound;
        fuenteAudio.Play();
    }

    public void cannonPlaySound() {
        fuenteAudio.clip = cannonSound;
        fuenteAudio.Play();
    }

    public void diePlaySound(){
        fuenteAudio.clip = dieSound;
        fuenteAudio.Play();
    }

}
