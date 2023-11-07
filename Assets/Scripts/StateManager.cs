using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//code refactored from iHeartGameDev
public class StateManager : MonoBehaviour
{
    public BaseState currentState;
    public UnitBehaviour unitBehavScript;
    public List<BaseState> states = new List<BaseState>();
    // Start is called before the first frame update
    void Start()
    {
        unitBehavScript = this.GetComponent<UnitBehaviour>();
        //Debug.Log(states.Count);
        currentState = states[0];
        //currentState = idleState;   //set starting state for the state machine
        currentState.EnterState(this);  //'this' object holding this script will immediately call EnterState();
    }

    // Update is called once per frame
    void Update()
    {
        if (unitBehavScript.hitPoint < 0)
        {
            unitBehavScript.hitPoint = 0;
        }
        currentState.UpdateState(this); //'this' object holding this script will call UpdateState() every frame;
    }

    public void SwitchState(BaseState state)
    {
        currentState = state;
        state.EnterState(this);
    }
}
