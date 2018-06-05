using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;
using UnityEngine.PostProcessing;

public class startTextDialogueHolder7 : DialogueHolder {

	private GameObject player;

	protected override void Start () {
		dMan = FindObjectOfType<DialogueManager>();
		dMan.dialogueLines = dialogueLines;
		dMan.currentLine = 0;
		dMan.doNext = doNext;
		dMan.ShowDialogue();
	}

	protected override void doNext(int branch = 0) {

	}

}


