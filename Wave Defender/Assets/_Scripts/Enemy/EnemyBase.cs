using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBase : MonoBehaviour {

    public float speed;
    public float hp;

    public void Update() {
        movement();
    }

    public virtual void movement() {
        transform.Translate(-transform.forward * Time.deltaTime * speed);
    }
}
