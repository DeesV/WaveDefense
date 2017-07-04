using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Deze class inherit van zijn Parent Class EnemyNormal. Daar gebeurt alles zodat het hier niet nog een keer geschreven hoeft te worden. Alles wat hier gedaan wordt is niet meer dan wat waardes
// aanpassen zodat deze enemy een uniek object is.
public class EnemyHeavy : EnemyNormal {

    // Hier overriden we de Virtual Awake functie in de ParentClass. We passen een paar variabels aan om deze class uniek te maken. In dit geval een zware, slome maar sterke enemy.
    public override void Awake() {
        base.Awake();
        base.hp = 150;
        base.speed = 1;
        base.waitTime = 10;
        base.attackDamage = 20;
    }
}
