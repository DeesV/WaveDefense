﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHeavy : EnemyNormal {

    public override void Start() {
        base.hp = 150;
        base.speed = 2.5f;
    }
}
