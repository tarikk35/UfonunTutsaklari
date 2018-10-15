using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AdventureGame : MonoBehaviour {

    [SerializeField] Text textComponent;
    [SerializeField] State startingState;
    [SerializeField] Text pathText;
    enum gameStates
    {
        NotStarted,
        Started,
        Ended
    };
    gameStates gameState=gameStates.NotStarted;
    State currentState;

	// Use this for initialization
	void Start () {
        StartGame();
	}

	void StartGame()
    {
        gameState = gameStates.NotStarted;
        currentState = startingState;
        textComponent.text = currentState.GetStoryState();
        pathText.text = currentState.GetPath();
    }

	// Update is called once per frame
	void Update () {

         if(Input.anyKeyDown)
            ManageState();
	}

    void ManageState()
    {
        State[] nextStates = currentState.GetNextStates();

        if (gameState == gameStates.Started)
        {
            if (Input.GetKeyDown(KeyCode.Alpha1) && nextStates.Length >= 1)
            {
                FillTextboxes(nextStates, 1);
            }
            else if (Input.GetKeyDown(KeyCode.Alpha2) && nextStates.Length >= 2)
            {
                FillTextboxes(nextStates, 2);
            }
            else if (Input.GetKeyDown(KeyCode.Alpha3) && nextStates.Length == 3)
            {
                FillTextboxes(nextStates, 3);
            }
            if (currentState.GetPath() == "SON")
                gameState = gameStates.Ended;
        }

        else if(gameState==gameStates.Ended&&Input.GetKeyDown(KeyCode.R))
        {
            StartGame();
        }

        else if (gameState == gameStates.NotStarted && Input.GetKeyDown(KeyCode.Return))
        {
            gameState = gameStates.Started;
            FillTextboxes(nextStates, 1);
            gameState = gameStates.Started;
        }        
    }

    void FillTextboxes(State[] nextStates,int choice)
    {
        currentState = nextStates[choice-1];
        textComponent.text = currentState.GetStoryState();
        pathText.text = currentState.GetPath();
    }
}
