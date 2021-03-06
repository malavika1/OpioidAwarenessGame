using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class momDialogueHolder9 : DialogueHolder {

    public Transform goal;
    private NavMeshAgent agent;
	private GameObject cube;

	IEnumerator getHelp()
	{
		yield return new WaitForSecondsRealtime(2);
		Initiate.Fade("GetHelp",Color.black,0.5f);	
	}

	protected override void doNext(int branch = 0) {
        AudioSource audio = GetComponent<AudioSource>();

        audio.Play();
		this.disableDialogueZone ();
        StartCoroutine (getHelp ());
    }
   
}
