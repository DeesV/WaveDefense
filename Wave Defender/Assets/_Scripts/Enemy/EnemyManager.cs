using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour {

    public int[] enemyCount;
    public List<GameObject> enemyPref = new List<GameObject>();
    GameObject[] spawner;

    public void Start() {
        spawner = GameObject.FindGameObjectsWithTag("Spawner");
    }

    public void Update() {
        spawnerVoid();
    }                
    
    public void spawnerVoid() {
        if (Input.GetButtonDown("Fire1")) {
            foreach (int i in enemyCount) {
                foreach (GameObject g in spawner) {
                    Instantiate(enemyPref[enemyPref.Count], g.transform.position + new Vector3(0,1,0), Quaternion.identity);
                }
            }
        }
    }
}       
