using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;
using UnityEngine.PostProcessing;

public class startTextDialogueHolder0 : DialogueHolder {
	
	protected override void Start () {
		dMan = FindObjectOfType<DialogueManager>();

		dMan.dialogueLines = dialogueLines;
		dMan.instructions = choiceInstructions;

		dMan.numBranches = numBranches;
		dMan.currentLine = 0;
		dMan.doNext = doNext;

		dMan.ShowDialogue();

	}

	protected override void doNext(int branch = 0) {
		if (branch == 2) {
			StartCoroutine (JumpScene (branch));
		} else {
			dMan.currentLine = 0;
			dMan.ShowDialogue();
		}
	}

	IEnumerator JumpScene(int branch)
	{	
		yield return new WaitForSecondsRealtime(2);
		Initiate.Fade("Scene1",Color.white,0.5f);
	}
		   
}


