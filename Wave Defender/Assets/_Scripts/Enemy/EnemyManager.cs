using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour {

    public int[] enemyCount;
    int waveAmount;
    public int maxWaveAmount;
    int chosenWaveAmount;

    public List<GameObject> enemyPref = new List<GameObject>();
    GameObject chosenEnemy;
    int prefChooser;

    GameObject[] spawner;



    public void Start() {
        spawner = GameObject.FindGameObjectsWithTag("Spawner");
    }

    public void Update() {
        StartCoroutine(spawnerVoid(3.5f));
    }

public IEnumerator spawnerVoid(float waitTime) {
        if (Input.GetButtonDown("Fire1")) {
            waveAmount = Random.Range(0, maxWaveAmount);
            chosenWaveAmount = enemyCount[waveAmount];
            foreach (int i in enemyCount) {
                foreach (GameObject g in spawner) {
                    yield return new WaitForSeconds(waitTime);
                    prefChooser = Random.Range(0, enemyPref.Count);
                    chosenEnemy = enemyPref[prefChooser];
                    Instantiate(chosenEnemy, g.transform.position + new Vector3(0,1,0), Quaternion.identity);
                }
            }
        }
    }
}       
