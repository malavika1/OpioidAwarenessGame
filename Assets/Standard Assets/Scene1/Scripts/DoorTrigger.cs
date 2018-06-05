using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTrigger : MonoBehaviour {

    private GameObject friend;

    // Use this for initialization
    void Start () {
        // Get the friend's reference and set to inactive.
        friend = GameObject.Find("Friend");
        friend.SetActive(false);
    }
	
	// Update is called once per frame
	void Update () {
		
	}

	IEnumerator waitForTheFriend() {
		yield return new WaitForSeconds(0.5f);
		friend.SetActive(true);
	}

    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.name == "Mom")
        {
            // make the mom disappear
            Vector3 pos = other.transform.position;
            other.gameObject.SetActive(false);

			// make the friend appear
			StartCoroutine (waitForTheFriend ());
        }
    }
}
