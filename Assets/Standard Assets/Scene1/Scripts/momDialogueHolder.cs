using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class momDialogueHolder : DialogueHolder {

    public Transform goal;
    private NavMeshAgent agent;

    protected override void doNext(int branch = 0) {
        agent = GetComponentsInParent<NavMeshAgent>()[0];
        goal = GameObject.Find("Door").transform;
        agent.destination = goal.position;
		agent.speed = 0.5f;
		this.disableDialogueZone ();
    }
   
}
