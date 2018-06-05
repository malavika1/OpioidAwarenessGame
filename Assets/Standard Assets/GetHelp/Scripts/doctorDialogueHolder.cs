using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class doctorDialogueHolder : DialogueHolder {

	protected override void doNext(int branch = 0) {
		if (branch == 1) {
			this.disableDialogueZone ();
			Initiate.Fade ("quiz", Color.white, 0.5f);
		} else {
			dMan.currentLine = 0;
			dMan.ShowDialogue ();
		}

    }
   
}