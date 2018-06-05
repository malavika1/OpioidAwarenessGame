using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueHolder : MonoBehaviour {

    public string[] dialogueLines;
    protected DialogueManager dMan;
	public string choiceInstructions;
	public int numBranches;
    
    // Use this for initialization
    protected virtual void Start () {
        dMan = FindObjectOfType<DialogueManager>();
    }
    
    // Update is called once per frame
    void Update () {
        
    }        

	protected void disableDialogueZone() {
		BoxCollider box = this.GetComponent<BoxCollider> ();
		if (box != null) {
			box.enabled = false;
		}
	}

	protected void disableAllDialogueZones() {
		
		DialogueHolder[] dZones = FindObjectsOfType<DialogueHolder>();
		foreach (DialogueHolder dzone in dZones){
			dzone.disableDialogueZone ();
		}
	}

    protected virtual void doNext(int branch = 0){

    }

    void OnTriggerStay(Collider other)
    {
        if(other.gameObject.name == "Player")
        {
            if(Input.GetKeyDown(KeyCode.Tab))
            {
                if(!dMan.dialogActive)
                {
                    dMan.dialogueLines = dialogueLines;
					dMan.instructions = choiceInstructions;
					dMan.numBranches = numBranches;
                    dMan.currentLine = -1;
                    dMan.doNext = doNext;
                    dMan.ShowDialogue();

                }
            }
        }
    }
}
