using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class QuizGameController : MonoBehaviour {
	public Text questionDisplayText;
	public Text scoreDisplayText;
	public Text endDisplayText;
	//public SimpleObjectPool answerButtonObjectPool;
	//public Transform answerButtonParent;
	public GameObject[] answerButtonObjects;
	public GameObject returnButtonGameObject;
	public GameObject continueButtonGameObject;
	public GameObject questionDisplay;
	public GameObject roundEndDisplay;
	public RoundData currentRoundData;

	private QuestionData[] questionPool;

	private int questionIndex;
	private int playerScore;

	// Use this for initialization
	void Start () 
	{
		// Get the mouse
		Cursor.lockState = CursorLockMode.None;
		Cursor.visible = true;
	}

	private void showInfoText() {
		QuestionData questionData = questionPool [questionIndex];
		questionDisplayText.text = questionData.informativeText;

		//Assert (qustionData.answers.Length == AnswerButtonObjects.Length);

		for (int i = 0; i < questionData.answers.Length; i++) 
		{
			GameObject answerButtonGameObject = answerButtonObjects [i];
			answerButtonGameObject.SetActive (false);
		}
		continueButtonGameObject.SetActive (true);
		
	}

	private void ShowQuestion()
	{
		QuestionData questionData = questionPool [questionIndex];
		questionDisplayText.text = questionData.questionText;

		//Assert (qustionData.answers.Length == AnswerButtonObjects.Length);

		for (int i = 0; i < questionData.answers.Length; i++) 
		{
			GameObject answerButtonGameObject = answerButtonObjects [i];
			answerButtonGameObject.SetActive (true);
			AnswerButton answerButton = answerButtonGameObject.GetComponent<AnswerButton>();
			answerButton.Setup(questionData.answers[i]);
		}
		continueButtonGameObject.SetActive (false);
	}


	public void AnswerButtonClicked(bool isCorrect)
	{
		if (isCorrect) 
		{
			playerScore += currentRoundData.pointsPerAnswer;
			scoreDisplayText.text = "Score: " + playerScore.ToString();
		}
		PlaySound (isCorrect);
		showInfoText ();



	}
	public void ContinueButtonClicked() {
		if (questionPool.Length > questionIndex + 1) {
			questionIndex++;
			ShowQuestion ();
		} else 
		{
			EndRound();
		}
		
	}

	public void StartRound() {
		questionDisplay.SetActive (true);
		roundEndDisplay.SetActive (false);
		questionPool = currentRoundData.questions;
		questionIndex = 0;
		playerScore = 0;
		scoreDisplayText.text = "Score: " + playerScore.ToString();

		continueButtonGameObject.SetActive (false);
		ShowQuestion ();
		
	}
	public void EndRound()
	{
		ReturnButton returnButton = returnButtonGameObject.GetComponent<ReturnButton>();

		if (playerScore >= 0.75 * currentRoundData.pointsPerAnswer * currentRoundData.questions.Length) {
			endDisplayText.text = "Congratulations! You know your stuff.";

			returnButton.returnText.text = "End the game.";
			returnButton.markAsCompleted ();

		} else {
			int numAnswered = playerScore / currentRoundData.pointsPerAnswer;
			string message = string.Format("You answered {0} out of {1} questions correctly." +
										   " Press the button to try again.",
											numAnswered, currentRoundData.questions.Length);
			endDisplayText.text = message;
			returnButton.returnText.text = "Try Again!";
		}
			
		questionDisplay.SetActive (false);
		roundEndDisplay.SetActive (true);
	}
		


	public void PlaySound(bool isCorrect)
	{
		AudioSource[] sounds = GetComponents<AudioSource>();
		if (isCorrect) {
			
			sounds [0].Play ();
		} else {
			sounds [1].Play ();
		}

	}


		

}