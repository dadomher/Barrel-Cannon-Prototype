using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ImputManager : MonoBehaviour {

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ReturnMenu() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex-1);
    }
}
