using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// De EnemyManager Class is de class die alles wat betreft het spawnen van de enemies regelt.
public class EnemyManager : MonoBehaviour {

    public int[] enemyCount;

    public float spawnDelay;
    public float waveTimer;
    int waveReset;

    public List<GameObject> enemyPref = new List<GameObject>();
    GameObject chosenEnemy;
    int prefChooser;

    GameObject[] spawner;


    // De Awake definieert alle spawners in de scene.
    public void Awake() {
        spawner = GameObject.FindGameObjectsWithTag("Spawner");
        StartCoroutine(spawnerVoid());
    }

    
    //Deze IEnumerator regelt welke enemies waar en hoe mogen spawnen. Het aantal per wave is aanpasbaar doormiddel van de int enemyCount. De waves resetten zichzelf ook.
    public IEnumerator spawnerVoid() {
        print("Begin" + waveReset);
        foreach (int i in enemyCount) {
            foreach (GameObject g in spawner) {
                yield return new WaitForSeconds(spawnDelay);
                prefChooser = Random.Range(0, enemyPref.Count);
                chosenEnemy = enemyPref[prefChooser];
                Instantiate(chosenEnemy, g.transform.position + new Vector3(0,1,0), Quaternion.identity);
                print("After" + waveReset);
            }
            waveReset += 1;
            if (waveReset == enemyCount.Length) {
                print("waveReset reached!");
                waveReset = 0;
                yield return new WaitForSeconds(waveTimer);
                StartCoroutine(spawnerVoid());
            }
        }
    }
}       
