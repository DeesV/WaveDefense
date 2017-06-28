using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour {

    RaycastHit gunHit;
    public float gunCheckDis;
    public PlayerController pControl;
    public Vector3 bounceBackR;
    public Vector3 bounceBackL;
    public Transform baseMid;

    void Start() {
        pControl = GetComponent<PlayerController>();
    }

    void Update() {
        GunInteraction();
    }

    public void GunInteraction() {
        if (Physics.Raycast(transform.position, transform.forward, out gunHit, gunCheckDis)) {
            if (gunHit.transform.tag == "Gun") {
                if (Input.GetButtonDown("E")) {
                    print("Turret Entered");
                }
            }
        }
    }


    void OnCollisionEnter(Collision collision) {
        if(collision.transform.tag == "WallR") {
            transform.position += bounceBackR;
        }
        else if(collision.transform.tag == "WallL") {
            transform.position += bounceBackL;
        }
    }
}
