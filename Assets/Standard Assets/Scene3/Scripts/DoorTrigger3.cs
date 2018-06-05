using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTrigger3 : MonoBehaviour {
	
    // Use this for initialization
    void Start () {

    }
	
	// Update is called once per frame
	void Update () {
		
	}
		
    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.name == "Mom")
        {
            // make the mom disappear
            Vector3 pos = other.transform.position;
            other.gameObject.SetActive(false);
        }
    }
}
