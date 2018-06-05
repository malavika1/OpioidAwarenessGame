using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTrigger9 : MonoBehaviour {

    private GameObject mom;

    // Use this for initialization
    void Start () {
        // Get the mom's reference and set to inactive.
        mom = GameObject.Find("Mom");
        mom.SetActive(false);
    }
	
	// Update is called once per frame
	void Update () {
		
	}

	IEnumerator waitForTheMom() {
		yield return new WaitForSeconds(0.5f);
		mom.SetActive(true);
	}

    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.name == "Player")
        {
			// Check that dialog box active fisrt
			DialogueManager dMan = FindObjectOfType<DialogueManager>();
			if(!dMan.dialogActive) {
				// make the mom appear
				StartCoroutine (waitForTheMom ());
			}

        }
    }
}
