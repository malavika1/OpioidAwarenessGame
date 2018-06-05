using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTrigger5 : MonoBehaviour {
	
    // Use this for initialization
    void Start () {

    }
	
	// Update is called once per frame
	void Update () {
		
	}
		
    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.name == "Boyfriend")
        {
            // make the boyfriend disappear
            Vector3 pos = other.transform.position;
            other.gameObject.SetActive(false);
			StartCoroutine(JumpScene());
        }
    }

	IEnumerator JumpScene()
	{
		yield return new WaitForSecondsRealtime(2);
		Initiate.Fade("Scene6", Color.white, 0.5f);

	}
}
