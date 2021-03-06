	using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class bfDialogueHolder : DialogueHolder {

    public Transform goal;
    private NavMeshAgent agent;
	private GameObject cube;

    protected override void doNext(int branch) {
		this.disableDialogueZone ();
        if (branch == 1)
        {
            StartCoroutine(JumpHelp());
        }
        else if (branch == 2)
        {
            // make the boyfriend leave
            agent = GetComponentsInParent<NavMeshAgent>()[0];
            goal = GameObject.Find("Door").transform;
            agent.destination = goal.position;
            agent.speed = 0.5f;
        }
    }

    IEnumerator JumpHelp()
    {
        yield return new WaitForSecondsRealtime(2);
        Initiate.Fade("GetHelp", Color.white, 0.5f);

    }
}
