using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;
using UnityEngine.PostProcessing;

public class cubeDialogueHolder6 : DialogueHolder {
	GameObject sceneCounter;
	public string objectToSell;

	protected override void Start () {
		dMan = FindObjectOfType<DialogueManager>();
		sceneCounter = GameObject.Find("SceneCounter");
		SceneCount s= sceneCounter.GetComponent ("SceneCount") as SceneCount;

		if (s.objectsSold.ContainsKey (objectToSell)) {
			this.disableDialogueZone ();
		}

		if (s.objectsSold.ContainsKey("laptop")) {
			GameObject laptop = GameObject.Find ("laptop");
			if (laptop != null) {
				laptop.SetActive (false);
			}

		}
			
	}
		
    protected override void doNext(int branch = 0) {
		StartCoroutine(JumpScene(branch));

    }

	IEnumerator JumpScene(int branch)
	{	

		if (branch == 1) {
			this.disableAllDialogueZones ();
			SceneCount s= sceneCounter.GetComponent ("SceneCount") as SceneCount;
			s.sellObject (objectToSell);


			yield return new WaitForSecondsRealtime(2);
			DontDestroyOnLoad (sceneCounter);
			Initiate.Fade("Scene6",Color.white,0.5f);
		}

	}
   
}


