using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Credits : MonoBehaviour {
	public int creditTime;
	// Use this for initialization
	void Start () {
		StartCoroutine (JumpScene ());
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	IEnumerator JumpScene()
	{	
		yield return new WaitForSecondsRealtime(creditTime);
		SceneManager.LoadScene ("StartMenu");
		//Initiate.Fade("StartMenu",Color.white,0.2f);

		// change music
	}
}
