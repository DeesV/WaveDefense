using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Deze class regelt alles watbetreft de speler. De movement, de borderbounce en de wapeninteractie worden hier besproken.
public class PlayerManager : MonoBehaviour {

    RaycastHit gunHit;
    public float gunCheckDis;
    Vector3 bounceBackR;
    Vector3 bounceBackL;

    public Vector3 moveDir;
    public float moveSpeed;

    // in de Update worden de movement en Interaction aangeroepen.
    void Update() {
        GunInteraction();
        Movement();
    }

    //De movement wordt gebasseerd door de input van de horizontale knoppen A en D. Vervolgens wordt die input vermenigvuldigt met Time.deltaTime en de snelheid van de speler.
    public void Movement() {
        moveDir = new Vector3(Input.GetAxis("Horizontal"), 0, 0);
        transform.Translate(moveDir * Time.deltaTime * moveSpeed);
    }

    //Hier wordt alle interactie met de wapens bijgehouden. Zodra de speler op E drukt in de buurt van een gun kan de speler deze gebruiken om de enemies af te vechten. 
    //Bij elk schot wordt er een sein gegeven naar de juiste loop van het juiste wapen en die schiet dan een kogel af.
    public void GunInteraction() {
        if (Physics.Raycast(transform.position, transform.forward, out gunHit, gunCheckDis)) {
            if (gunHit.transform.tag == "MainGun") {
                if (Input.GetButton("E")) {
                    gunHit.transform.GetComponent<Guns>().inMainGun = true;
                }
                else {
                    gunHit.transform.GetComponent<Guns>().inMainGun = false;
                }
            }
        }
    }

    //Deze functie zorgt ervoor dat de speler niet uit de map kan. Een klein simpel knockbackje doet het goed!
    void OnCollisionEnter(Collision collision) {
        if(collision.transform.tag == "WallR") {
            transform.position += bounceBackR;
        }
        else if(collision.transform.tag == "WallL") {
            transform.position += bounceBackL;
        }
    }
}
