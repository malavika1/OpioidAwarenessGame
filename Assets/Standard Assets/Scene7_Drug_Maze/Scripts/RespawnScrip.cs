using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnScrip : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.name == "Player")
		{
			AudioSource a = GetComponent<AudioSource>();
			a.Play();

			StartCoroutine(waitt(other));


//			other.gameObject.SetActive(false);


		}
	}


	IEnumerator waitt(Collider other)
	{
		if (other.name == "Player") {
			yield return new WaitForSecondsRealtime (2);
			other.gameObject.transform.position = new Vector3 (3, 1, -18);
			other.gameObject.transform.eulerAngles = new Vector3 (0, -90, 0);		
		} 
	}
}
