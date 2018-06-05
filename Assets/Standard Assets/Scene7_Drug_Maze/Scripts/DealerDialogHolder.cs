using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class DealerDialogHolder : DialogueHolder {



	IEnumerator transition()
	{
		yield return new WaitForSecondsRealtime(1);
		MusicPlayer m = FindObjectOfType<MusicPlayer>();
		m.StopMusic (); // swap to other player in level 8
		Initiate.Fade("Scene8",Color.white,0.5f);	


	}

	protected override void doNext(int branch = 0) {
		AudioSource a = GetComponent<AudioSource>();
		a.Play();
		this.disableDialogueZone ();
		StartCoroutine (transition ());

	}

}

