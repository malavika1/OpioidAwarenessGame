using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;
using System;

public class DialogueManager : MonoBehaviour {

    public GameObject dBox;
    public Text dText;
	public Text instructionText;

    public bool dialogActive;

    public string[] dialogueLines;
    public int currentLine;

    public delegate void onDialogueComplete(int branch);
    public onDialogueComplete doNext;

    private int curBranch;
	public int numBranches;
    private bool waitingForResponse;

	public string instructions;
	private string defaultInstructions;

    // Use this for initialization
    void Start () {
        curBranch = 0;
		if (instructions == null) {
			instructions = "";
		}
		defaultInstructions = "Press Tab to continue";
    }

    // Update is called once per frame
    void Update() {
        if (waitingForResponse) {

            string choice = Input.inputString;
            if (choice.Length == 1) {

                bool result = Int32.TryParse(choice, out curBranch);
				if (result && curBranch > 0 && curBranch <= numBranches) {
                    currentLine++;
                    waitingForResponse = false;
				
                }

            }
    
        }
        else if (dialogActive && Input.GetKeyDown(KeyCode.Tab))
        {
            currentLine++;

        }

        if(currentLine >= dialogueLines.Length)
        {
            dBox.SetActive(false);
            dialogActive = false;

            currentLine = 0;
            int temp = curBranch;
            curBranch = 0;
            if (doNext != null)
            {
                doNext(temp);
            }
        }

        // display the line only if it is part of the correct branch
		if(dialogueLines.Length > 0 && !waitingForResponse)
        {
            string lineText = dialogueLines[currentLine];
            int lineBranch;


			if (lineText.StartsWith ("#Q")) {
				waitingForResponse = true;
				instructionText.text = instructions;
			} else {
				instructionText.text = defaultInstructions;
			}

            // skip over lines from different branches
            while (currentLine < dialogueLines.Length) {
                lineText = dialogueLines[currentLine];
                lineBranch = getLineBranch (lineText);

                if (lineBranch == curBranch) {
                    dText.text = getDisplayText (lineText);
                    break;
                } 

                currentLine++;
            }
        }
    }

    public void ShowDialogue()
    {
        dialogActive = true;
        dBox.SetActive(true);
    }

    public int getLineBranch(string lineText){
        if (!lineText.StartsWith ("#")) {
            return 0;
        }
        if (lineText [1] == 'Q') {
            return 0;
        } else {
            return Int32.Parse(lineText[1].ToString());
        }
    }
    public string getDisplayText(string lineText){
        if (!lineText.StartsWith ("#")) {
            return lineText;
        }
        return lineText.Substring (2, lineText.Length - 2);
    }
        
}
    