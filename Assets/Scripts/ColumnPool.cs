using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColumnPool : MonoBehaviour {

    public int barrelPoolSize = 5;
    public GameObject barrelPrefab;
    public float spawnRate = 5f;
    public float barrelMin = -4f;
    public float barrelMax = 4f;
 

    private GameObject[] barrels;
    private Vector2 objectPoolPosition = new Vector2(-15f, -25f);
    private float timeSinceLastSpawned = 0;
    private float spawnXPosition = 8f;
    private int currentBarrel = 0;


	// Use this for initialization
	void Start () {
        barrels = new GameObject[barrelPoolSize];
        for (int i = 0; i < barrelPoolSize; i++) {
            barrels[i] = (GameObject)Instantiate(barrelPrefab, objectPoolPosition, Quaternion.identity);
        }

        createBarrel(8, 0);
    }
	
	// Update is called once per frame
	void Update () {
        timeSinceLastSpawned += Time.deltaTime;
        //barrels[currentBarrel].transform.position = new Vector2(0, 0);
  
        if (GameControl.instance.gameOver == false && timeSinceLastSpawned >= spawnRate) {
            float spawnYPosition = Random.Range(barrelMin, barrelMax);
            timeSinceLastSpawned = 0;

            createBarrel(spawnXPosition, spawnYPosition);
        }
	}

    void createBarrel(float x, float y) {
        barrels[currentBarrel].transform.position = new Vector2(x, y);

        //print(barrels[currentBarrel].transform.position);
        currentBarrel++;
        if (currentBarrel >= barrelPoolSize)
        {
            currentBarrel = 0;
        }
    }
}
