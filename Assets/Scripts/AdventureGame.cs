using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AdventureGame : MonoBehaviour {

    [SerializeField] Text textComponent;
    [SerializeField] State startingState;
    [SerializeField] Text pathText;

    State currentState;
	// Use this for initialization
	void Start () {
        currentState = startingState;
        textComponent.text = currentState.GetStoryState();
        pathText.text = currentState.GetPath();
	}
	
	// Update is called once per frame
	void Update () {
        ManageState();
	}

    void ManageState()
    {
        State[] nextStates = currentState.GetNextStates();
        if(Input.GetKeyDown(KeyCode.Alpha1)&& nextStates.Length>=1)
        {
            currentState = nextStates[0];
            textComponent.text = currentState.GetStoryState();
        }
        else if(Input.GetKeyDown(KeyCode.Alpha2)&& nextStates.Length>=2)
        {
            currentState = nextStates[1];
            textComponent.text = currentState.GetStoryState();
        }
        else if(Input.GetKeyDown(KeyCode.Alpha3) && nextStates.Length==3)
        {
            currentState = nextStates[2];
            textComponent.text = currentState.GetStoryState();
        }
        pathText.text = currentState.GetPath();
    }
}
