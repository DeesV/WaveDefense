﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Deze class staat op elke bullet die geinstantiate wordt in de Guns Class. Dit regelt dat de kogel vooruit vliegt en kapot gaat zodra het moet.
public class Bullet : MonoBehaviour {

    BulletKind myTestBullet = new BulletKind(30, 35);

    // De update roept de juiste move functie aan.
    void Update() {
        moveBullet();
    }

    // De move functie zorgt alleen maar voor movement in de kogel.
    void moveBullet() {
        transform.GetComponent<Rigidbody>().velocity = transform.forward * myTestBullet.speed;
    }

    //Deze functie zorgt ervoor dat de kogel kapot gaat zodra hij een ander object aanraakt.
    void OnCollisionEnter(Collision collision) {
        Destroy(gameObject);
    }

}

public class BulletKind {
    public float speed;
    public float damage;

    public BulletKind(float _speed,float _damage) {
        speed = _speed;
        damage = _damage;
    }
}

