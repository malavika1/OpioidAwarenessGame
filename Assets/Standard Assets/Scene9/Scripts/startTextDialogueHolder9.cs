using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;
using UnityEngine.PostProcessing;

public class startTextDialogueHolder9 : DialogueHolder {

    private GameObject player;

    protected override void Start () {
		dMan = FindObjectOfType<DialogueManager>();
		dMan.dialogueLines = dialogueLines;
		dMan.currentLine = 0;
		dMan.doNext = doNext;
		dMan.ShowDialogue();
	}

	protected override void doNext(int branch = 0) {
		MusicPlayer[] players = FindObjectsOfType<MusicPlayer> ();
		int ind = 0;
		if (players.Length > 1) {
			ind = 1;
		}
				
			
		// if (players[0].numTracks() 
		MusicPlayer m = FindObjectsOfType<MusicPlayer> ()[ind];
		//AudioSource audio = GetComponent<AudioSource>();
		m.changeMusic (3);

        player = GameObject.Find("Player");
        GameObject mainCamera = player.transform.GetChild(0).gameObject;
        PostProcessingBehaviour highScript = mainCamera.GetComponent<PostProcessingBehaviour>();
        highScript.enabled = true;
    }
		   
}


