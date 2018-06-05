using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class doctorDialogueHolderScene4 : DialogueHolder {

//	private NavMeshAgent agent;

	protected override void doNext(int branch = 0) {
		this.disableDialogueZone ();
		StartCoroutine(Example());

	}

	IEnumerator Example()
	{
		yield return new WaitForSecondsRealtime(2);
		Initiate.Fade("Scene5",Color.white,0.5f); 

	}
}
