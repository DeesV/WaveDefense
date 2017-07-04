using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Deze class zorgt ervoor dat de juiste guns de kogels afvuren.
public class Guns : MonoBehaviour {

    public bool inMainGun = false;
    GameObject mainLoop;

    public GameObject bullet;

    //De awake in deze class definieert de loop waaruit de kogels moeten schieten.
    public void Awake() {
        mainLoop = transform.GetChild(0).GetChild(0).gameObject;
    }

    //De update houd op een simpele manier in de gaten of het wapen gebruikt wordt. De boolean wordt op true en false gezet in het PlayerManager script onder de interactie.
    public void Update() {
        if(inMainGun == true) {
            UsingMainGun();
        }
    }

    //Deze functie, die aangeroepen wordt vanuit de update zodra het nodig is, registreert elke klik op de linkermuisknop om vervolgens een kogel te instantiaten.
    //De kogel heeft zelf alle waardes die hij nodig heeft.
	public void UsingMainGun() {
        if (Input.GetButtonDown("Fire1")) {
            Instantiate(bullet, mainLoop.transform.position, Quaternion.identity);
        }
    }
}

