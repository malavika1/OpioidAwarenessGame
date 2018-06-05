using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeMusic : MonoBehaviour {
	MusicPlayer m;
	public int trackSelection;
	// Use this for initialization
	void Awake () {
		int ind = FindObjectsOfType<MusicPlayer> ().Length;
		// This has to be the last music player object to be one that is in use
		// for some reason when a new one is made for the scene but not used, it is the first object
		m = FindObjectsOfType<MusicPlayer> ()[ind - 1];
		if (!m.isActive()) {
			m = FindObjectsOfType<MusicPlayer> ()[0];
		}
		if (m != null) {
			m.changeMusic (trackSelection);
		} 
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
