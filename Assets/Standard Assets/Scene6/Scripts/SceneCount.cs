using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneCount : MonoBehaviour {

	public int numObjects;

	public Dictionary<string, bool> objectsSold =
		new Dictionary<string, bool>();

	public void sellObject(string s) {
		objectsSold.Add (s, true);
	}

	public bool objectsLeftToSell(){
		return objectsSold.Count < numObjects;
	}
}
