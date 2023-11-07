using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//code refactored from iHeartGameDev
public class StateManager : MonoBehaviour
{
    public BaseState currentState;
    public UnitBehaviour unitBehavScript;
    public List<BaseState> states = new List<BaseState>();
    bool isPlaying;
    // Start is called before the first frame update
    void Start()
    {
        isPlaying = true;
        unitBehavScript = this.GetComponent<UnitBehaviour>();
        Debug.Log(states.Count);
        currentState = states[0];
        //currentState = idleState;   //set starting state for the state machine
        currentState.EnterState(this);  //'this' object holding this script will immediately call EnterState();
    }

    // Update is called once per frame
    public void Activate()
    {
        if (unitBehavScript.hitPoint <= 0)
        {
            unitBehavScript.hitPoint = 0;
            isPlaying = false;
        }
        if (isPlaying)
        {
            currentState.UpdateState(this); //'this' object holding this script will call UpdateState() every frame;
            
        }
        if (!isPlaying)
        {
            Debug.Log("GAME OVER!");
        }
    }

    public void SwitchState(BaseState state)
    {
        currentState = state;
        state.EnterState(this);
    }
}
