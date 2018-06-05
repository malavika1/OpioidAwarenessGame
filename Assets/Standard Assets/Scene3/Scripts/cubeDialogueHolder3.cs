using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;
using UnityEngine.PostProcessing;

public class cubeDialogueHolder3 : DialogueHolder {

	private GameObject player;

    protected override void doNext(int branch = 0) {
		this.disableDialogueZone ();
		StartCoroutine(Example());

    }

	IEnumerator Example()
	{
		yield return new WaitForSecondsRealtime(2);
		Initiate.Fade("Scene4_Doctor",Color.white,0.5f);	


	}
   
}


