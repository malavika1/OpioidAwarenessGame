using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuButtons : MonoBehaviour {

	public void Start()
	{
		
	}
	public void StartClick()
	{
		SceneManager.LoadScene ("Scene0");
	}

	public void ShowCredits()
	{
		SceneManager.LoadScene ("Credits");

	}
}