using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AI : MonoBehaviour {

    public List<GameObject> targets = new List<GameObject>();
    public NavMeshAgent agent;

    bool firstTime;

    void Awake() {
        agent = GetComponent<NavMeshAgent>();
        agent.SetDestination(targets[Random.Range(0, targets.Count)].transform.position);
        StartCoroutine(Movement());
    }

    public IEnumerator Movement() {
        if(agent.remainingDistance > agent.stoppingDistance) {
            StartCoroutine(Movement());
        }
        else if(agent.remainingDistance <= agent.stoppingDistance) {
            yield return new WaitForSeconds(10);
            agent.SetDestination(targets[Random.Range(0, targets.Count)].transform.position);
            StartCoroutine(Movement());
        }
    }

}
