using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRunner : EnemyNormal {

    public override void Start() {
        base.hp = 50;
        base.speed = 10;
    }
}
