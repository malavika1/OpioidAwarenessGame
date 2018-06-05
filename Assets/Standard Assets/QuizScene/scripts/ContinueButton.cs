using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ContinueButton : MonoBehaviour {

	private QuizGameController gameController;

	// Use this for initialization
	void Start () 
	{
		gameController = FindObjectOfType<QuizGameController> ();
	}
		

	public void HandleClick()
	{
		gameController.ContinueButtonClicked ();
	}
}