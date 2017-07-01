using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public Vector3 moveDir;
    public float moveSpeed;

    // Use this for initialization
    void Start () {

    }

    // Update is called once per frame
    void Update () {
        Movement();

    }

    public void Movement() {
        moveDir = new Vector3(Input.GetAxis("Horizontal"), 0, 0);
        transform.Translate(moveDir * Time.deltaTime * moveSpeed);
    }

}
