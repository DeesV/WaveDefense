using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHeavy : EnemyBase {

    public override void movement() {
        base.movement();
        base.hp = 10;
    }
}
