using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : BaseState
{
    public override void EnterState(StateManager state)
    {
        Debug.Log("State: " + state.currentState);
        state.unitBehavScript.attacking = false;

    }
    public override void UpdateState(StateManager state)
    {
        if (state.unitBehavScript.hitPoint <= 0)
        {
            state.unitBehavScript.hitPoint = 0;
            state.unitBehavScript.slider.value = 0;
            Debug.Log(state.unitBehavScript.name + " died");
            state.unitBehavScript.gameObject.SetActive(false);
        }

        float aggValue = state.unitBehavScript.aggressionValue;

        float percentHP = (state.unitBehavScript.hitPoint / state.unitBehavScript.maxHP);
        percentHP = Mathf.Round(percentHP * 10f) / 10f;
        float randValue = Random.Range(0f, 1f);
        randValue = Mathf.Round(randValue * 10f) / 10f;

        switch (aggValue)
        {
            case float when percentHP <= 0.3f:
                aggValue -= 0.3f;
                break;
            case float when percentHP <= 0.5:
                aggValue -= 0.2f;
                break;
            case float when percentHP <= 0.7:
                aggValue -= 0.1f;
                break;
            default:
                break;
        }
        if (aggValue < 0.1f)
        {
            aggValue = 0.1f;
        }

        float randAggRoll = Random.Range(0.1f, aggValue + 0.1f);
        randAggRoll = Mathf.Round(randAggRoll * 10f) / 10f;

        if (percentHP == 1f || aggValue >= randAggRoll || randValue < percentHP)
        {
            state.SwitchState(state.states[1]);
        }
        else
        {
            state.SwitchState(state.states[3]);
        }
    }
}
