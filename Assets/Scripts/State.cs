using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="State")] 
public class State : ScriptableObject {

  [TextArea(20,14)] [SerializeField] string storyText;
    [SerializeField] State[] nextStates;
    [TextArea(10, 3)] [SerializeField] string pathText;

    public string GetStoryState()
    {
        return storyText;
    }
    public string GetPath()
    {
        return pathText;
    }

    public State[] GetNextStates()
    {
        return nextStates;
    }
}
