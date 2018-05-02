using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrelController : MonoBehaviour {
    public Sprite barrel_off, barrel_on;
    public GameObject barDirection, playerShell;
    public AnimationClip rotate;

    GameObject barDirection_clone, playerShell_clone;
    float xBarrel, yBarrel, rotBarrel;
    private Animation animationRotate;

    // Use this for initialization
    void Start () {
        
    }
	
	// Update is called once per frame
	void Update () {
        //Detectar si aprieta la tecla "ESPACIO"
        if (this.GetComponent<SpriteRenderer>().sprite == barrel_on && Input.GetKeyDown(KeyCode.Space)) {
            FirePlayer();
        }
    }

    //Funcion para activar las propiedades del barril cuando contiene el personaje (sprite, direccion, etc)
    void BarrelContainPlayer() {
            this.GetComponent<SpriteRenderer>().sprite = barrel_on;
            barDirection_clone = Instantiate(barDirection, transform) as GameObject;
            if (this.GetComponent<Animator>().enabled == false) this.GetComponent<Animator>().enabled = true;
    }

    //Funcion para activar las propiedades del barril cuando NO contiene el personaje (sprite, direccion, etc)
    void BarrelNotContainPlayer() {
        this.GetComponent<Animator>().enabled = false;
        this.GetComponent<SpriteRenderer>().sprite = barrel_off;
        Destroy(barDirection_clone);
    }

        //Funcion para disparar al jugador
    void FirePlayer() {
        //Almacenamos ciertas propiedades del barril
        xBarrel = transform.position.x;
        yBarrel = transform.position.y;
        rotBarrel = transform.eulerAngles.z;

        BarrelNotContainPlayer();

        setBarrelOutput();

        //Instanciamos al jugador para que salga disparado
        playerShell_clone = Instantiate(playerShell, new Vector3(xBarrel, yBarrel, transform.position.z), transform.rotation) as GameObject;

        animationRotate = playerShell_clone.AddComponent<Animation>();
        animationRotate.AddClip(rotate, "rotate");
        animationRotate.Play("rotate");
    }

    //Calculamos donde estara posicionado el jugador cuando sea disparado segun la rotacion del objeto
    void setBarrelOutput() {
        if (rotBarrel <= 360 && rotBarrel >= 271) {
            xBarrel += 1f;
            yBarrel += 1f;
        } else if (rotBarrel <= 270 && rotBarrel >= 181) {
            xBarrel += 1f;
            yBarrel -= 1f;
        } else if (rotBarrel <= 180 && rotBarrel >= 91) {
            xBarrel -= 1f;
            yBarrel -= 1f;
        } else  {
            xBarrel -= 1f;
            yBarrel += 1f;
        }
    }

    //Funcion para detectar la collision con el jugador
    void OnCollisionEnter2D(Collision2D collision) {
        if(collision.gameObject.CompareTag("player")) {
            //print(collision.gameObject);
            Destroy(collision.gameObject);
            BarrelContainPlayer();
        }
    }
}


