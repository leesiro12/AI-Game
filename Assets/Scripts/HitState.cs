using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitState : BaseState
{
    Combat combatScript;
    public HitState(Combat _combatScript)
    {
        combatScript = _combatScript;
    }

    public override void EnterState(StateManager state)
    {
        Debug.Log("Oof!");
    }
    public override void UpdateState(StateManager state)
    {
        state.SwitchState(state.states[0]);
        Debug.Log("To Idle");
    }
}
