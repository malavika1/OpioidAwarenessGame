using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class friendDialogueHolder : DialogueHolder {

	private GameObject cube;

    protected override void doNext(int branch = 0) {
		cube = GameObject.Find("Cube");
		GameObject dzone = cube.transform.GetChild (0).gameObject;
		Collider cubeBoxCollider = dzone.GetComponent<BoxCollider>();
		cubeBoxCollider.enabled = true;
    }
   
}
