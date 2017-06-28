using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour {

    RaycastHit wallHit;
    public float checkDis;
    public PlayerController pControl;

    void Start() {
        pControl = GetComponent<PlayerController>();
    }


	void Update() {
        if(Physics.Raycast(transform.position, transform.right, out wallHit, checkDis)) {
            if (wallHit.transform.tag == "Wall") {
                pControl.moveDir = new Vector3(-1,0,0);
            }
        }
    }
}
