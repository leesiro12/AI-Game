using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//code refactored from iHeartGameDev
public class StateManager : Manager
{
    public BaseState currentState;
    
    public UnitManager unitManagerScript;
    public List<BaseState> states = new List<BaseState>();

    // Start is called before the first frame update
    void Start()
    {
        unitBehavScript = GetComponent<UnitBehaviour>();
        //Debug.Log(states.Count);
        currentState = states[0];
        currentState.EnterState(this);  //'this' object holding this script will immediately call EnterState();
    }

    // Update is called once per frame
    public override void Activate()
    {
        if (unitManagerScript.isPlaying)
        {
            currentState.UpdateState(this); //'this' object holding this script will call UpdateState() every frame;
        }
        
    }
    private void Update()
    {
        
    }
    public void SwitchState(BaseState state)
    {
        currentState = state;
        state.EnterState(this);
    }
}
