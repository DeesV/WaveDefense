using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    /*Vector3 mouseInput;
    Vector3 lookhere;*/
    RaycastHit shootHit;

    // Use this for initialization
    void Start () {

    }

    // Update is called once per frame
    void Update () {
        transform.Rotate(Camera.main.ScreenToWorldPoint(Input.mousePosition));
        if (Input.GetButtonDown("Fire1")) {
            Physics.Raycast(transform.position, transform.forward, out shootHit, 30);
            Debug.DrawRay(transform.position, transform.forward, Color.blue, 30);
        }
    }
}
