using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//code refactored from iHeartGameDev
public class StateManager : MonoBehaviour
{
    public BaseState currentState;
    /*
    public IdleState idleState = new IdleState();
    public AttackState attackState = new AttackState();
    public HitState hitState = new HitState();
    */
    public List<BaseState> states = new List<BaseState>();
    // Start is called before the first frame update
    void Awake()
    {
        Debug.Log(states.Count);
        currentState = states[0];
        //currentState = idleState;   //set starting state for the state machine
        currentState.EnterState(this);  //'this' object holding this script will immediately call EnterState();
    }

    // Update is called once per frame
    void Update()
    {
        currentState.UpdateState(this); //'this' object holding this script will call UpdateState() every frame;
    }

    public void SwitchState(BaseState state)
    {
        currentState = state;
        state.EnterState(this);
    }
}
