using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyNormal : MonoBehaviour {

    public float speed;
    public float hp;
    RaycastHit dodgeCheck;
    public float dodgeCheckLength;

    public virtual void Start() {

    }

    public virtual void Update() {
        movement();
        healthManager();
    }

    public virtual void movement() {
        transform.Translate(-transform.forward * Time.deltaTime * speed);
    }

    public virtual void healthManager() {
        if (hp <= 0) {
            print("Enemy is Dead");
            Destroy(gameObject);
        }
        else if (Input.GetButtonDown("Fire2")) {
            hp -= 10;
        }
    }

}
