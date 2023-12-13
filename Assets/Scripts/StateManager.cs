using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//code refactored from iHeartGameDev
public class StateManager : MonoBehaviour
{
    public BaseState currentState;
    public UnitBehaviour unitBehavScript;
    public UnitManager unitManagerScript;
    public List<BaseState> states = new List<BaseState>();

    // Start is called before the first frame update
    void Start()
    {
        //unitBehavScript = GetComponent<UnitBehaviour>();
        //Debug.Log(states.Count);
        currentState = states[0];
        //currentState = idleState;   //set starting state for the state machine
        currentState.EnterState(this);  //'this' object holding this script will immediately call EnterState();
    }

    // Update is called once per frame
    public void Activate()
    {
        if (unitManagerScript.isPlaying)
        {
            currentState.UpdateState(this); //'this' object holding this script will call UpdateState() every frame;
        }
        else if (!unitManagerScript.isPlaying)
        {
            Debug.Log("GAME OVER!");
            Debug.Log(unitBehavScript.name + " Died!");
        }
    }

    public void SwitchState(BaseState state)
    {
        currentState = state;
        state.EnterState(this);
    }
}
