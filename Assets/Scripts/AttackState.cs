using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackState : BaseState
{
    public Combat combatScript;
    public AttackState(Combat _combatScript)
    {
        _combatScript.GetComponent<Combat>();
        combatScript = _combatScript;
        Debug.Log("isWorkingCorrectly");
    }
    public override void EnterState(StateManager state)
    {
        Debug.Log("WAH!");
    }
    public override void UpdateState(StateManager state)
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            if (combatScript!=null)
            {
                Debug.Log("Has sth");
            }
            else
            {
                Debug.Log("nothing");
            }
            Debug.Log("C is Pressed");
            combatScript.StartCoroutine(combatScript.HitSth());
            state.SwitchState(state.states[2]);
        }
    }
}
