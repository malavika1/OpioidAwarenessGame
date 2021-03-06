using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class momDialogueHolder3 : DialogueHolder {

    public Transform goal;
    private NavMeshAgent agent;
	private GameObject cube;

	IEnumerator getHelp()
	{
		yield return new WaitForSecondsRealtime(2);
		Initiate.Fade("GetHelp",Color.white,0.5f);	


	}

	protected override void doNext(int branch = 0) {
		this.disableAllDialogueZones ();

		if (branch == 2) {
			
			StartCoroutine (getHelp ());
		} else {
			// make the mom leave
			agent = GetComponentsInParent<NavMeshAgent>()[0];
			goal = GameObject.Find("Door").transform;
			agent.destination = goal.position;
			agent.speed = 0.5f;

			// allow you to search the cabinet again.
			cube = GameObject.Find("Cube");
			GameObject dzone = cube.transform.GetChild (0).gameObject;
			Collider cubeBoxCollider = dzone.GetComponent<BoxCollider>();
			cubeBoxCollider.enabled = true;
		}

    }
   
}
