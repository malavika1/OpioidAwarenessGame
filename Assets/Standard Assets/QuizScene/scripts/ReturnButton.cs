using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ReturnButton : MonoBehaviour {

	public Text returnText;
	private bool sendBackToStart = true;
	private bool started = false;

	public void markAsCompleted(){
		sendBackToStart = false;
	}

	private QuizGameController gameController;

	// Use this for initialization
	void Start () 
	{
		gameController = FindObjectOfType<QuizGameController> ();
	}


	public void HandleClick()
	{
		if (!started || sendBackToStart) {
			started = true;
			gameController.StartRound ();
		}  else {
			SceneManager.LoadScene ("Credits");
		}
	}
}