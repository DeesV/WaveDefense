using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Deze class regelt alles wat betreft de Player Basis, in dit geval is het alleen de HP.
public class BaseBase : MonoBehaviour {

    public float baseHP;

   //Deze functie wordt aangeroepen zodra een enemy in de buurt is. Die enemy geeft aan damage value mee en gebasseerd daarop neemt de basis damage/verliest de speler uiteindelijk.
    public void TakeDamage(float damage) {
        baseHP -= damage;
        if(baseHP <= 0) {
            Time.timeScale = 0;
            print("Game Over");
        }
    }

}
