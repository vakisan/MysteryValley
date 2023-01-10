﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour {

    [SerializeField]
    // private Transform target;
    private NavMeshAgent navMeshAgent;
    private State currentState;

    [Range(0,100)]
    public float speed = 5;

    [Range(0,100)]
    public float walkRadius = 25;
    private void Awake(){
        navMeshAgent = GetComponent<NavMeshAgent>();

        if(navMeshAgent != null){
            navMeshAgent.SetDestination(Roam());
        }
    }

    public Vector3 Roam(){
        Vector3 finalPosition = Vector3.zero;
        Vector3 randomPosition = Random.insideUnitSphere * walkRadius;
        randomPosition += transform.position;
        if(NavMesh.SamplePosition(randomPosition,out NavMeshHit hit, walkRadius,1)){
            finalPosition = hit.position;
        }
        return finalPosition;
    }

    void Update(){
        if(navMeshAgent!= null && navMeshAgent.remainingDistance <= navMeshAgent.stoppingDistance){
            navMeshAgent.SetDestination(Roam());
        }
    }

}