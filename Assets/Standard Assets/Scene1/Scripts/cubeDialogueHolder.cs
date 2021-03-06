using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;
using UnityEngine.PostProcessing;

public class cubeDialogueHolder : DialogueHolder {

	private GameObject player;

    protected override void doNext(int branch = 0) {
		player = GameObject.Find("Player");
		GameObject mainCamera = player.transform.GetChild(0).gameObject;
		PostProcessingBehaviour highScript = mainCamera.GetComponent<PostProcessingBehaviour>();
		highScript.enabled = true;
		this.disableAllDialogueZones ();

		StartCoroutine(JumpScene());

    }

	IEnumerator JumpScene()
	{
		yield return new WaitForSecondsRealtime(8);
		Initiate.Fade("Scene2",Color.white,0.5f);	

	}
   
}


