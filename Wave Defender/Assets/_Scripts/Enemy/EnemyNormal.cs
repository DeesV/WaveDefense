using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Dit is de class die alles regelt voor alle enemies. Alle andere enemies inheriten hier uit. Alles wat die hoeven aan te geven zijn hun eigen waardes in de start. De rest gebeurt vanzelf.
public class EnemyNormal : MonoBehaviour {

    public float speed;
    public float hp;
    public float attackDamage;
    public float waitTime;

    float lerpAmount = 0.2f;

    public GameObject playerBase;

    public float bulletDamage;

    //De Awake is de enige functie die Virtual is omdat deze als enige aangepast hoeft te worden door de childclasses. Hierin worden alle basis variabels gedfinieerd en de movement gestart.
    public virtual void Awake() {
        playerBase = GameObject.FindGameObjectWithTag("Base");
        hp = 100;
        speed = 2.5f;
        attackDamage = 10;
        waitTime = 6;
        bulletDamage = 35;
        StartCoroutine(EnemyMovement());
    }

    // In deze IEnumerator wordt alle movement voor de enemies geregeld. Zolang als de afstand tussen de enemy en hun doel niet klein genoeg is blijven ze lopen en anders vallen ze aan.
    public IEnumerator EnemyMovement() {
        while (Vector3.Distance(transform.position, playerBase.transform.position) > 4.8f) {
            transform.position = Vector3.Lerp(transform.position, playerBase.transform.position, lerpAmount * Time.deltaTime * speed);
            yield return null;
        }
        StartCoroutine(Attack(waitTime));
    }

    //Dit is de functie die in de gaten houd of de enemy geraakt wordt door een kogel. Als dat zo is wordt de healthManager aangeroepen om damage op te nemen.
    public void OnCollisionEnter(Collision col) {
        if (col.transform.tag == "Bullet") {
            HealthManager(bulletDamage);
        }
    }

    // De HealthManager is de plek waar alle schade die kogels doen geregistreert worden. de damage van de kogel wordt van de hp afgehaald en als de hp 0 is wordt de enemy gedestroyed.
    public void HealthManager(float bulletDamage) {
        hp -= bulletDamage;
        if (hp <= 0) {
            print("Enemy is Dead");
            Destroy(gameObject);
        }
    }

    // De Attack Numerator wordt aangeroepen zodra de distance tussen de enemy en hun doelwit klein genoeg is. Deze numerator doet direct schade op de basis doormiddel van de functie TakeDamage.
    public IEnumerator Attack(float waitTime) {
        print("Hello There, it is me! Attack!");
        playerBase.transform.GetComponent<BaseBase>().TakeDamage(attackDamage);
        yield return new WaitForSeconds(waitTime);
        StartCoroutine(Attack(waitTime));
    }
}
