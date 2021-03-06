using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;
using UnityEngine.PostProcessing;

public class startTextDialogueHolder6 : DialogueHolder {
	
	private GameObject sceneCounter;
	private bool jumpScenes = false;

	protected override void Start () {
		sceneCounter = GameObject.Find("SceneCounter");
		SceneCount s= sceneCounter.GetComponent ("SceneCount") as SceneCount;

		if (!s.objectsLeftToSell ()) {
			dialogueLines [0] = "You have run out of valuables that you can sell.";
			dialogueLines[1] = "You will have to find a cheaper drug to use.";
			jumpScenes = true;

		}
		else if (s.objectsSold.Count > 0){
			dialogueLines[0] = "Selling that funded your next fix, but you are out of money again.";
		}


		dMan = FindObjectOfType<DialogueManager>();
		dMan.dialogueLines = dialogueLines;
		dMan.currentLine = 0;
		dMan.doNext = doNext;
		dMan.ShowDialogue();



	}

	protected override void doNext(int branch = 0) {
		if (jumpScenes) {
			StartCoroutine(JumpScene(branch));
		}


	}

	IEnumerator JumpScene(int branch)
	{	
		Destroy (sceneCounter);
		yield return new WaitForSecondsRealtime(2);
		Initiate.Fade("Scene7",Color.white,0.5f);
	}
		   
}


